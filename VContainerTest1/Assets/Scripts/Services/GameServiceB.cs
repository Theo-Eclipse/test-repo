using System;
using Cysharp.Threading.Tasks;
using VContainer;
using Wolfdev.Services.API;

namespace Wolfdev.Services
{
    public class GameServiceB : BaseGameGameService<GameServiceB>
    {
        [Inject] private IMessengerService _messengerService;
        public override async UniTask Initialize(Action onSuccess = null, Action<string> onError = null)
        {
            await UniTask.Delay(2500);
            await UniTask.Yield();
            onSuccess?.Invoke();
            _messengerService.Publish($"Very interesting message from {nameof(GameServiceB)}!", this);
        }
    }
}