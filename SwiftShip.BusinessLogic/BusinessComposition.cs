using Microsoft.Extensions.DependencyInjection;
using SwiftShip.BusinessLogic.BusinessLogic;

namespace SwiftShip.BusinessLogic.Utils
{
    public static class BusinessComposition
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
          return  services.AddTransient<IParcelBusinessLogic, ParcelBusinessLogic>()
                          .AddTransient<IStageHistoryInitializer, StageHistoryInitializer>()
                          .AddTransient<IParcelStageHistoryBusinessLogic, ParcelStageHistoryBusinessLogic>()
                          .AddSingleton<IStageHandler, StageHandler>();
        }
    }

}
