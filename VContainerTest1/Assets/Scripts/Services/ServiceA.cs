using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using Wolfdev.Services.API;

namespace Wolfdev.Services
{
    public class ServiceA : IService, IDisposable
    {
        [Inject] private IMessengerService _messenger;
        public async UniTask Initialize()
        {
            Debug.Log($"{nameof(ServiceA)} doing something");
            _messenger.Subscribe<string>(OnMessageReceived, this);
            await UniTask.Delay(500);
            await UniTask.Yield();
        }

        private void OnMessageReceived(string message, object source = null)
        {
            var isService = source != null && source is IService;
            Debug.Log($"{nameof(ServiceA)} received message: {message}, isService: {isService}");
        }

        public void Dispose()
        {
            _messenger.Unsubscribe<string>(this);
        }
    }
}