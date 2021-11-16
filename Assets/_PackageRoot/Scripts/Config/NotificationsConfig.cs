using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace Extensions.Notifications
{
#pragma warning disable CA2235 // Mark all non-serializable fields
    public sealed class NotificationsConfig : SerializedScriptableObject
    {
                                        public const    string  PATH                        = "Assets/Resources/Notifications Settings.asset";
                                        public const    string  PATH_FOR_RESOURCES_LOAD     = "Notifications Settings";

        [BoxGroup("B", false), HorizontalGroup("B/H")]
        [TitleGroup("B/H/Settings")]    public bool             debug                       = true;
        [TitleGroup("B/H/Settings")]    public string	        iconSmall		            = "app_notification_small";
        //[TitleGroup("B/H/Settings")]    public List<string>		channels					= new List<string>(){ "default" };
    }
#pragma warning restore CA2235 // Mark all non-serializable fields
}