using VContainer;
using VContainer.Unity;
using Wolfdev.Services;
using Wolfdev.Services.API;
using Wolfdev.UI.LifeScopes;

namespace Wolfdev.LifeScopes
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<TestServiceA>(Lifetime.Scoped).As<ITestService>();
            builder.Register<TestServiceB>(Lifetime.Scoped).As<ITestService>();
            
            builder.RegisterEntryPoint<MainBootstrapper>().AsSelf();
            builder.RegisterEntryPoint<ServiceInitializer>();
        }
    }
}
