using BlocklyPro.Core.AppService;
using BlocklyPro.Core.AppService.Interfaces;
using BlocklyPro.Core.Infrastructure;
using BlocklyPro.Core.Utility;
using Microsoft.Extensions.DependencyInjection;

namespace BlocklyPro.Api.Configurations
{
    public static class IocConfig
    {
        public static IServiceCollection RegisterApplicationDependancies(this IServiceCollection services)
        {
            services.AddTransient<ICoreInjector, CoreInjector>();
            services.AddTransient<IIdentityAppService, IdentityAppService>();
            services.AddTransient<IGameAppService, GameAppService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBlocklyDbContext, BlocklyDbContext>();
            services.AddTransient<IGameRunnerAppService, GameRunnerAppService>();
            return services;
        }
    }
}
