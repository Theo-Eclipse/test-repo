using MessagePipe;
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
            var options = builder.RegisterMessagePipe();
            // Setup GlobalMessagePipe to enable diagnostics window and global function
            builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));

            // RegisterMessageBroker: Register for IPublisher<T>/ISubscriber<T>, includes async and buffered.
            builder.RegisterMessageBroker<int>(options);
            
            builder.Register<TestServiceA>(Lifetime.Scoped).As<ITestService>();
            builder.Register<TestServiceB>(Lifetime.Scoped).As<ITestService>();
            
            builder.RegisterEntryPoint<MainBootstrapper>().AsSelf();
            builder.RegisterEntryPoint<ServiceInitializer>();
        }
    }
}
