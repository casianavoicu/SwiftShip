using Microsoft.Extensions.DependencyInjection;

namespace SwiftShip.Service
{
    public static class ServiceComposition
    {
        public static IServiceCollection AddDbServices(this IServiceCollection services)
        {
            return services.AddScoped<IParcelService, ParcelService>()
                           .AddScoped<IStageService, StageService>();

        }
    }
}
