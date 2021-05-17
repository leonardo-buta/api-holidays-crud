using Holidays.Data.Context;
using Holidays.Data.Repository;
using Holidays.Data.UoW;
using Holidays.Domain.Interfaces;
using Holidays.Services.Auth;
using Holidays.Services.Interfaces;
using Holidays.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Holidays.Data.IoC
{
    public class DI
    {
        public static void RegisterServices(IServiceCollection services)
        {            
            // Services
            services.AddScoped<IHolidayAppService, HolidayAppService>();
            services.AddScoped<IHolidayVariableDateAppService, HolidayVariableDateAppService>();
            services.AddScoped<IUserAppService, UserAppService>();

            // Repositories
            services.AddScoped<IHolidayRepository, HolidayRepository>();
            services.AddScoped<IHolidayVariableDateRepository, HolidayVariableDateRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Auth
            services.AddScoped<IJwtAuthManager, JwtAuthManager>();

            // Context
            services.AddScoped<HolidaysContext>();
        }
    }
}
