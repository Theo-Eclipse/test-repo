using Cysharp.Threading.Tasks;
using UnityEngine;
using Wolfdev.Services.API;

namespace Wolfdev.Services
{
    public class TestServiceA : ITestService
    {
        public async UniTask DoStuff()
        {
            Debug.Log($"{nameof(TestServiceA)} doing something");
            await UniTask.Delay(1500);
            await UniTask.Yield();
        }
    }
}