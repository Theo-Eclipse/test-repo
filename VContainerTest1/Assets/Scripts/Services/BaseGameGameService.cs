using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using Wolfdev.Services.API;

namespace Wolfdev.Services
{
    public abstract class BaseGameGameService<T> : IGameService, IDisposable
    {
        [Inject] protected IMessengerService Messenger { get; private set; }

        public string Name => typeof(T).Name;

        public abstract UniTask Initialize(Action onSuccess = null, Action<string> onError = null);

        public virtual void Dispose()
        {
            Debug.Log($"Service {Name} disposed and unsubscribed from messenger.");
            Messenger.UnsubscribeAll(this);
        }
    }
}