using VContainer;
using VContainer.Unity;
using Wolfdev.UI.LifeScopes;

namespace Wolfdev.LifeScopes
{
    public class SceneLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MainBootstrapper>().AsSelf();
        }
    }
}