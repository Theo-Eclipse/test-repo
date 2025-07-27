using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using Wolfdev.Services.API;

namespace Wolfdev.Services
{
    public class ServiceB : IService
    {
        [Inject] private IMessengerService _messengerService;
        public async UniTask Initialize()
        {
            Debug.Log($"{nameof(ServiceB)} doing something");
            await UniTask.Delay(2500);
            await UniTask.Yield();
            _messengerService.Publish($"Very interesting message from {nameof(ServiceB)}!", this);
        }
    }
}