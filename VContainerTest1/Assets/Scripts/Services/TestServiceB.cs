using Cysharp.Threading.Tasks;
using UnityEngine;
using Wolfdev.Services.API;

namespace Wolfdev.Services
{
    public class TestServiceB : ITestService
    {
        public async UniTask DoStuff()
        {
            Debug.Log($"{nameof(TestServiceB)} doing something");
            await UniTask.Delay(2500);
            await UniTask.Yield();
        }
    }
}