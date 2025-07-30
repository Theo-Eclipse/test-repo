using System.IO;

namespace Wolfdev.Settings
{
    public static class ConfigSettings
    {
        private static readonly string Root = UnityEngine.Application.streamingAssetsPath;
        public static readonly string Configs = Path.Combine(Root, nameof(Configs));
        public static readonly string Mods = Path.Combine(Root, nameof(Mods));
    }
}