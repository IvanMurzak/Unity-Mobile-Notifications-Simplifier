using System;
using UnityEngine;

namespace Extensions.Notifications
{
    public static class NotificationsInitializer
    {
        public static NotificationsConfig settings { get; private set; } = CreateSettingsConfig();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
#pragma warning disable IDE0051 // Remove unused private members
#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#endif
        internal static void Init()
#pragma warning restore IDE0051 // Remove unused private members
        {
            RefreshSettingsFromConfig();
        }

        public static void RefreshSettingsFromConfig()
        {
            if (settings == null) settings = CreateSettingsConfig();
        }

        internal static NotificationsConfig GetExistingDefaultUnitySettings() => settings;

        private static NotificationsConfig CreateSettingsConfig()
        {
            try
            {
                var config = Resources.Load<NotificationsConfig>(NotificationsConfig.PATH_FOR_RESOURCES_LOAD);
                if (!config)
                {
                    Debug.Log($"Creating new Notifications Config into Resources folder");
                    config = ScriptableObject.CreateInstance<NotificationsConfig>();
                }
                return config;
            } 
            catch (Exception e)
			{
                Debug.LogException(e);
			}

            return null;
        }
    }
}