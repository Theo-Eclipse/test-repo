using MessagePipe;
using VContainer;
using VContainer.Unity;
using Wolfdev.Configs;
using Wolfdev.Configs.API;
using Wolfdev.Services;
using Wolfdev.Services.API;
using Wolfdev.UI.LifeScopes;

namespace Wolfdev.LifeScopes
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            var options = builder.RegisterMessagePipe();
            // Setup GlobalMessagePipe to enable diagnostics window and global function
            builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));

            // RegisterMessageBroker: Register for IPublisher<T>/ISubscriber<T>, includes async and buffered.
            builder.RegisterMessageBroker<int>(options);
            builder.Register<MessengerService>(Lifetime.Singleton).As<IMessengerService>();

            RegisterConfigs(builder);
            RegisterGameServices(builder);
            
            builder.RegisterEntryPoint<MainBootstrapper>().AsSelf();
            builder.RegisterEntryPoint<ServiceInitializer>();
        }

        private void RegisterGameServices(IContainerBuilder builder)
        {
            builder.Register<ConfigManager>(Lifetime.Scoped).As<IGameService>();
            builder.Register<GameServiceA>(Lifetime.Scoped).As<IGameService>();
            builder.Register<GameServiceB>(Lifetime.Scoped).As<IGameService>();
        }
        
        private void RegisterConfigs(IContainerBuilder builder)
        {
            builder.Register<MainConfig>(Lifetime.Scoped).As<IConfig>();
        }
    }
}
