using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using Wolfdev.Configs.API;

namespace Wolfdev.Services
{
    public class ConfigManager : BaseGameGameService<ConfigManager>
    {
        [Inject] private readonly IEnumerable<IConfig> _configs;
        private readonly string _configsPath = Application.persistentDataPath;
        public override async UniTask Initialize(Action onSuccess = null, Action<string> onError = null)
        {
            Debug.Log($"Loading configs...");

            foreach (var config in _configs)
            {
                Debug.Log($"Loading config \"{config.Type.Name}\"");
            }

            Debug.Log($"Configs loaded!");
            await UniTask.WaitForFixedUpdate();
        }

        private void LoadOrCreateDefault(IConfig config)
        {
            
        }

        private bool TryLoadConfig<T>(string path, out T config) where T : class
        {
            var configPath = Path.Combine(path, $"{typeof(T).Name}.xml");
            if (File.Exists(configPath))
            {
                try
                {
                    using var stream = File.OpenRead(configPath);
                    var serializer = new XmlSerializer(typeof(T));
                    config = (T)serializer.Deserialize(stream);
                    return true;
                }
                catch (Exception e)
                {
                    Debug.LogError($"Failed to load config: {e.Message}");
                }
            }
            else
            {
                Debug.LogError($"No config found at path: {configPath}");
            }

            config = null;
            return false;
        }

        private bool TrySaveConfig<T>(T config, string path) where T : class
        {
            var configPath = Path.Combine(path, $"{typeof(T).Name}.xml");
            try
            {
                using var stream = File.Create(configPath);
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stream, config);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to save config: {e.Message}");
            }
            return false;
        }
    }
}