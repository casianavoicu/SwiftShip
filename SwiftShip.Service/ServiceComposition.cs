using Microsoft.Extensions.DependencyInjection;

namespace SwiftShip.Service
{
    public static class ServiceComposition
    {
        public static IServiceCollection AddDbServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IParcelService, ParcelService>()
                .AddTransient<IStageService, StageService>();
        }
    }
}
