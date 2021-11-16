#if UNITY_ANDROID
using System;
using System.Collections.Generic;
using Unity.Notifications.Android;

namespace Extensions.Notifications
{
	public static class MobileNotifications_Android
	{
		private const	string							ICON_NOTIFICATION_SMALL		= "app_small";
		private static	Dictionary<string, bool>		CHANNEL_REGISTERED			= new Dictionary<string, bool>();

		private static void RegisterNotificationChannel(string identifier, string name, string description)
		{
			var unregistered = !CHANNEL_REGISTERED.ContainsKey(identifier) || !CHANNEL_REGISTERED[identifier];
			if (unregistered)
			{ 
				AndroidNotificationCenter.RegisterNotificationChannel(new AndroidNotificationChannel()
				{
					Id			= identifier,
					Name		= name,
					Importance	= Importance.High,
					Description = description
				});
				CHANNEL_REGISTERED[identifier] = true;
			}
		}
	
		public static void SendNotification(string identifier, string title, string text, DateTime fireTime, string largeIcon = null, string channelName = "", string channelDescription = "", string smallIcon = ICON_NOTIFICATION_SMALL)
		{
			RegisterNotificationChannel(identifier, channelName, channelDescription);

			var notification = new AndroidNotification()
			{
				Title				= title,
				Text				= text,
				FireTime			= fireTime,
				Group				= identifier,
				GroupSummary		= true,
				ShouldAutoCancel	= true
			};

			if (largeIcon != null) notification.LargeIcon	= largeIcon;
			if (smallIcon != null) notification.SmallIcon	= smallIcon;
			
			AndroidNotificationCenter.SendNotification(notification, identifier);
		}
		public static void CancelAllScheduledNotifications()
		{
			AndroidNotificationCenter.CancelAllScheduledNotifications();
		}
	}
}
#endif