using Cysharp.Threading.Tasks;

namespace Wolfdev.Services.API
{
    public interface IService
    { 
        UniTask Initialize();
    }
}