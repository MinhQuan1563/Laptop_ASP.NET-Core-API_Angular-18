using Microsoft.Extensions.DependencyInjection;
using WAAL.Domain.Interfaces;
using WAAL.Persistence.Repositories;

namespace WAAL.Persistence.ServiceRegister
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ICardDoHoaRepository, CardDoHoaRepository>();
            services.AddScoped<IMauSacRepository, MauSacRepository>();
            services.AddScoped<INhaCungCapRepository, NhaCungCapRepository>();
            
            return services;
        }
    }
}
