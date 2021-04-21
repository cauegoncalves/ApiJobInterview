using System;
using Microsoft.Extensions.DependencyInjection;
using cgds.manufacture.application.Interfaces;
using cgds.manufacture.application.Services;
using cgds.manufacture.reposity.inmemory;
using cgds.manufacture.service.simplifieddeliverystorage;

namespace cgds.manufacture.ioc
{
    public static class Startup
    {
        public static IServiceCollection AddManufactureApplication(this IServiceCollection services)
        {
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddTransient<IDeliveryStorage, SimplifiedDeliveryStorage>();
            services.AddTransient<IOrderService, OrderFacade>();
            return services;
        }
    }
}
