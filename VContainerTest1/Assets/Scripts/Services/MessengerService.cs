using System;
using System.Collections.Generic;
using MessagePipe;
using Wolfdev.MessagePipe;
using Wolfdev.Services.API;

namespace Wolfdev.Services
{
    public class MessengerService : IMessengerService
    {
        private readonly Dictionary<(Type, object), IDisposable> _subscriptions = new();
        private readonly IServiceProvider _provider;

        public MessengerService(IServiceProvider provider)
        {
            _provider = provider;
        }
        
        public void Publish<T>(T payload, object source = null)
        {
            var publisher = _provider.GetRequiredService<IPublisher<BaseMessagePayload<T>>>();
            publisher.Publish(new BaseMessagePayload<T>(payload, source));
        }

        public void Subscribe<T>(Action<T, object> handler, object subscriber)
        {
            var key = (typeof(T), subscriber);
            
            if (_subscriptions.ContainsKey(key)) 
                return;
            
            var service = _provider.GetRequiredService<ISubscriber<BaseMessagePayload<T>>>();
            var disposable = service.Subscribe(payload => handler(payload.Data, payload.Source));
            _subscriptions[key] = disposable;
        }
        
        public void Unsubscribe<T>(object subscriber)
        {
            var key = (typeof(T), subscriberId: subscriber);
            
            if (!_subscriptions.TryGetValue(key, out var disposable)) 
                return;
            
            disposable.Dispose();
            _subscriptions.Remove(key);
        }
        
        public void UnsubscribeAll(object subscriber)
        {
            var keysToRemove = new List<(Type, object)>();
            foreach (var sub in _subscriptions)
            {
                if (sub.Key.Item2 == subscriber)
                {
                    keysToRemove.Add(sub.Key);
                }
            }

            foreach (var key in keysToRemove)
            {
                _subscriptions[key].Dispose();
                _subscriptions.Remove(key);
            }
        }
    }
}