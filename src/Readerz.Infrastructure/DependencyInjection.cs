using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reader.Application.Common.Interfaces;
using Readerz.Infrastructure.Translator;
using Readerz.Infrastructure.Translator.Identity;
using Readerz.Infrastructure.Translator.Persistence;
using Readerz.Infrastructure.Translator.Services.TextProcessing;

namespace Readerz.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment environment)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ReaderzDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }
            
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            
            services.AddTransient<IUserManager, UserManagerService>();
            services.AddTransient<ITextProcessingService, TextProcessingService>();
            services.AddTransient<ITranslationService, TranslationService>();
            
            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
            
            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        } 
    }
}