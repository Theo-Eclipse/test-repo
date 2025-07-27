using System;
using Cysharp.Threading.Tasks;

namespace Wolfdev.Services.API
{
    public interface IGameService
    { 
        string Name { get; }
        UniTask Initialize(Action onSuccess = null, Action<string> onError = null);
    }
}