using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reader.Application.Common.Interfaces;


namespace Readerz.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ReaderzDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    opts => opts.MigrationsAssembly("Readerz.Persistence")
                ));

            services.AddScoped<IReaderzDbContext>(provider => provider.GetService<ReaderzDbContext>());
            
            return services;
        }
    }
}