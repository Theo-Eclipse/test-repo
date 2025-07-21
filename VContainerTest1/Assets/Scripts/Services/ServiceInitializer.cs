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
        private readonly IEnumerable<ITestService> services;
        
        public ServiceInitializer(IEnumerable<ITestService> services)
        {
            this.services = services;
        }
        
        public async UniTask StartAsync(CancellationToken cancellation)
        {
            Debug.Log($"Initializing all {nameof(ITestService)} implementations in order...");

            foreach (var service in services)
            {
                await service.DoStuff();
            }

            Debug.Log($"All {nameof(ITestService)} implementations initialized.");
        }
    }
}