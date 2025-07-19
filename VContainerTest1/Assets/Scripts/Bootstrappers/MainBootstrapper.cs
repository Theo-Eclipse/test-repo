using UnityEngine;
using VContainer.Unity;

namespace Wolfdev.UI.LifeScopes
{
    public class MainBootstrapper : IStartable
    {
        public void Start()
        {
            Debug.Log("MainBootstrapper started...");
        }
    }
}
