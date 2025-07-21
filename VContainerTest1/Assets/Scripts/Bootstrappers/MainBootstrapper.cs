using System;
using UnityEngine;
using VContainer.Unity;

namespace Wolfdev.UI.LifeScopes
{
    public class MainBootstrapper : IInitializable, IDisposable
    {
        public void Initialize()
        {
            Debug.Log("MainBootstrapper Initialized!");
        }

        public void Dispose()
        {
            Debug.Log($"{nameof(MainBootstrapper)} has been disposed...");
            // TODO release managed resources here
        }
    }
}
