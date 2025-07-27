using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;
using Wolfdev.Services.API;

namespace Wolfdev.Services
{
    public class ServiceInitializer : IAsyncStartable
    {
        private readonly IEnumerable<IGameService> _services;
        
        public ServiceInitializer(IEnumerable<IGameService> services)
        {
            _services = services;
        }
        
        public async UniTask StartAsync(CancellationToken cancellation)
        {
            Debug.Log($"Initializing all {nameof(IGameService)} implementations in order...");

            foreach (var service in _services)
            {
                Debug.Log($"Initializing service \"{service.Name}\"");
                await service.Initialize(null, (message) => OnInitError(service, message));
            }

            Debug.Log($"All {nameof(IGameService)} implementations initialized.");
        }
        
        private void OnInitError(IGameService gameService, string message)
        {
            Debug.LogError($"<color=red>Error Initializing Service: \"{gameService.Name}\"</color>\n: {message}");
        }
    }
}