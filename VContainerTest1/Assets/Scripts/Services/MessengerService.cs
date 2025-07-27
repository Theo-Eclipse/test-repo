using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Subscribe<T>(Action<T, object> handler, object subscriberId)
        {
            var key = (typeof(T), subscriberId);
            
            if (_subscriptions.ContainsKey(key)) 
                return;
            
            var subscriber = _provider.GetRequiredService<ISubscriber<BaseMessagePayload<T>>>();
            var disposable = subscriber.Subscribe(payload => handler(payload.Data, payload.Source));
            _subscriptions[key] = disposable;
        }
        
        public void Unsubscribe<T>(object subscriberId)
        {
            var key = (typeof(T), subscriberId);
            
            if (!_subscriptions.TryGetValue(key, out var disposable)) 
                return;
            
            disposable.Dispose();
            _subscriptions.Remove(key);
        }
        
        public void UnsubscribeAll(object subscriberId)
        {
            var keysToRemove = _subscriptions
                .Where(pair => Equals(pair.Key.Item2, subscriberId))
                .Select(pair => pair.Key)
                .ToList();

            foreach (var key in keysToRemove)
            {
                _subscriptions[key].Dispose();
                _subscriptions.Remove(key);
            }
        }
    }
}