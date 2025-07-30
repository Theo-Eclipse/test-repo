using System;
using Wolfdev.Configs.API;

namespace Wolfdev.Configs
{
    public abstract class Config<T> : IConfig
    {
        public Type Type => typeof(T);
        public string Name => typeof(T).Name;
    }
}