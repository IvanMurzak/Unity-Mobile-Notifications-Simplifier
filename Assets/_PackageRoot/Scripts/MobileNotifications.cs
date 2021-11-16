using System;

namespace Extensions.Notifications
{ 
	public static class MobileNotifications
	{
		static NotificationsConfig Config => NotificationsInitializer.settings;

		public static void SendNotification(string channel, string title, string text, DateTime fireTime, string largeIcon = null, string channelName = "", string channelDescription = "", string smallIcon = null)
		{
			if (string.IsNullOrEmpty(smallIcon))
            {
				smallIcon = Config.iconSmall;
            }

	#if UNITY_ANDROID
			MobileNotifications_Android.SendNotification(channel, title, text, fireTime, largeIcon, channelName, channelDescription, smallIcon);
	#elif UNITY_IOS
			MobileNotifications_iOS.SendNotification(channel, title, "", text, fireTime);
	#endif
		}
		public static void CancelAllScheduledNotifications()
		{
	#if UNITY_ANDROID
			MobileNotifications_Android.CancelAllScheduledNotifications();
	#elif UNITY_IOS
			MobileNotifications_iOS.CancelAllScheduledNotifications();
	#endif
		}
	}
}