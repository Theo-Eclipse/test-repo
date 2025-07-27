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
        private readonly IEnumerable<IService> services;
        
        public ServiceInitializer(IEnumerable<IService> services)
        {
            this.services = services;
        }
        
        public async UniTask StartAsync(CancellationToken cancellation)
        {
            Debug.Log($"Initializing all {nameof(IService)} implementations in order...");

            foreach (var service in services)
            {
                await service.Initialize();
            }

            Debug.Log($"All {nameof(IService)} implementations initialized.");
        }
    }
}