using VContainer;
using VContainer.Unity;
using Wolfdev.UI.LifeScopes;

namespace Wolfdev.LifeScopes
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MainBootstrapper>();
        }
    }
}
