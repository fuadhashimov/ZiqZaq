using Microsoft.Extensions.DependencyInjection;
using ZiqZaq.Logic;
using ZiqZaq.Logic.Infrastructure;

namespace ZiqZaq.Web.Core.Modules
{
    internal class LogicModule
    {
        public static void Load(IServiceCollection services)
        {
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IVendorLogic, VendorLogic>();
        }
    }
}