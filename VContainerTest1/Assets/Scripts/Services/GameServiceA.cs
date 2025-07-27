using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Wolfdev.Services.API;

namespace Wolfdev.Services
{
    public class GameServiceA : BaseGameGameService<GameServiceA>
    {
        public override async UniTask Initialize(Action onSuccess = null, Action<string> onError = null)
        {
            Messenger.Subscribe<string>(OnMessageReceived, this);
            await UniTask.Delay(500);
            await UniTask.Yield();
            onSuccess?.Invoke();
        }

        private void OnMessageReceived(string message, object source = null)
        {
            var isService = source is IGameService;
            Debug.Log($"{nameof(GameServiceA)} received message: {message}, isService: {isService}");
        }
    }
}