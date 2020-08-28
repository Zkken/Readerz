using System.Reflection;
using MediatR;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Reader.Application.CardSets.Queries.GetCardSets;

namespace Reader.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<CardSetDto>();
            
            return services;
        }
    }
}