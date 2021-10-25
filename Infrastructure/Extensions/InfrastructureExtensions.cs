using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NUCAL.Application.Core.Interfaces.Services;
using NUCAL.Application.Core.Services;
using System;
using IMapperCore = NUCAL.Application.Core.Interfaces.IMapper;
using MapperCore = NUCAL.Infrastructure.Mapping.Mapper;

namespace NUCAL.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IMapperCore, MapperCore>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUsersManagerService, UserManagerService>();
            services.AddTransient<IFoodCategoriesService, FoodCategoriesService>();
            services.AddTransient<IFoodsService, FoodsService>();
            services.AddTransient<IConsumedFoodsService, ConsumedFoodsService>();
            return services;
        }
    }
}
