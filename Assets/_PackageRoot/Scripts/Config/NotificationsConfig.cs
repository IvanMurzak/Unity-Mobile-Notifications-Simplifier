using Sirenix.OdinInspector;

namespace Extensions.Notifications
{
#pragma warning disable CA2235 // Mark all non-serializable fields
    public sealed class NotificationsConfig : SerializedScriptableObject
    {
                                                public const    string  PATH                        = "Assets/Resources/Notifications Settings.asset";
                                                public const    string  PATH_FOR_RESOURCES_LOAD     = "Notifications Settings";

        [BoxGroup("B", false), HorizontalGroup("B/H")]
        [TitleGroup("B/H/Settings")]            public bool             debug                       = true;
        [BoxGroup("B2", false), HorizontalGroup("B2/H")]
        [InfoBox("Unity Notification Settings should contains the icon with the same name.")]
        [TitleGroup("B2/H/Settings Android")]   public string	        iconAndroidSmall		    = "app_notification_small";
        [InfoBox("Unity Notification Settings should contains the icon with the same name.")]
        [TitleGroup("B2/H/Settings Android")]   public string	        iconAndroidLarge		    = "app_notification_large";


#if UNITY_EDITOR
        //Object Settings => UnityEditor.Unsupported.GetSerializedAssetInterfaceSingleton("NotificationsSettings");
        [GUIColor(0.5f, 0.6f, 0.9f, 1)]
        [Button(ButtonSizes.Large), PropertySpace]
        void UnityNotificationSettings()
        {
            UnityEditor.SettingsService.OpenProjectSettings("Project/Mobile Notifications");
        }
#endif
    }
#pragma warning restore CA2235 // Mark all non-serializable fields
}