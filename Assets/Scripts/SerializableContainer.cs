// namespace Core.Gameplay.Info
// {
    using UnityEngine;
    using Sirenix.OdinInspector;
    using System;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;


    public abstract class SerializableContainer : GenericContainer
    {
        public abstract void LoadConfig(string config);
        public abstract object GetData();

        protected T DeserializeConfig<T>(string json, T localData)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

#if UNITY_EDITOR
        [SerializeField] TextAsset configFile = null;

        [Button]
        public void LoadConfigFromFile()
        {
           // Verify<ArgumentNullException>.IsNotNull(configFile.text, nameof(configFile));
            LoadConfig(configFile.text);
        }
#endif

    }
// }
