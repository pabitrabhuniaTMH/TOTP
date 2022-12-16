using Microsoft.Extensions.DependencyInjection;
using OTPServices.Services;
using OTPServices.Services.IRepository;
namespace OTPServices
{
    public static class Service
    {
        public static IServiceCollection ConfigureOTPServices(this IServiceCollection services)
        {
            services.AddScoped<IOTPGenerateService,OTPGenerateService>();
            return services;
        }
    }
}
