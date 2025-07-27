using System;

namespace Wolfdev.Services.API
{
    public interface IMessengerService
    {
        void Publish<T>(T payload, object source = null);
        
        void Subscribe<T>(Action<T, object> handler, object subscriber);

        void Unsubscribe<T>(object subscriber);
        
        void UnsubscribeAll(object subscriber);
    }
}