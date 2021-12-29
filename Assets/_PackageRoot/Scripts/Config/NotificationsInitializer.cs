using System;
using UnityEngine;

namespace Extensions.Notifications
{
    public static class NotificationsInitializer
    {
        private static NotificationsConfig _config = null;
        public static NotificationsConfig Config => _config == null ? _config = LoadOrCreateConfig() : _config;

        private static NotificationsConfig LoadOrCreateConfig()
        {
            var config = Resources.Load<NotificationsConfig>(NotificationsConfig.PATH_FOR_RESOURCES_LOAD);
            if (!config) throw new NullReferenceException("Analytics config was not found");
            return config;
        }
    }
}