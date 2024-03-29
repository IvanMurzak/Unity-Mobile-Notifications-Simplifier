﻿using System;
using UnityEngine;

namespace Extensions.Notifications
{ 
	public static class MobileNotifications
	{
		static NotificationsConfig Config => NotificationsInitializer.Config;

		public static void Send(string channel, string title, string text, string largeIcon = null, string channelName = "default", string channelDescription = "Default", string smallIcon = null)
        {
			Schedule(channel, title, text, DateTime.Now + TimeSpan.FromMilliseconds(250), largeIcon, channelName, channelDescription, smallIcon);
		}
		public static void Schedule(string channel, string title, string text, TimeSpan timeOffset, string largeIcon = null, string channelName = "default", string channelDescription = "Default", string smallIcon = null)
		{
			Schedule(channel, title, text, DateTime.Now + timeOffset, largeIcon, channelName, channelDescription, smallIcon);
		}
		public static void Schedule(string channel, string title, string text, DateTime fireTime, string largeIcon = null, string channelName = "default", string channelDescription = "Default", string smallIcon = null)
		{
			if (string.IsNullOrEmpty(smallIcon)) smallIcon = Config.iconAndroidSmall;
			if (string.IsNullOrEmpty(largeIcon)) largeIcon = Config.iconAndroidLarge;

			if (Config.debug) 
				Debug.Log($"MobileNotifications.Schedule: channel={channel}, title={title}, fireTime={fireTime}, largeIcon={largeIcon}, channelName={channelName}, channelDescription={channelDescription}, smallIcon={smallIcon}");

#if UNITY_ANDROID
			MobileNotifications_Android.Schedule(channel, title, text, fireTime, largeIcon, channelName, channelDescription, smallIcon);
#elif UNITY_IOS
			MobileNotifications_iOS.Schedule(channel, title, "", text, fireTime);
#endif
		}
		public static void CancelAllScheduled()
		{
			if (Config.debug)
				Debug.Log($"MobileNotifications.CancelAllScheduled");
			
#if UNITY_ANDROID
			MobileNotifications_Android.CancelAllScheduled();
#elif UNITY_IOS
			MobileNotifications_iOS.CancelAllScheduled();
#endif
		}

		public static void ClearBadgeCounteriOS()
		{
			if (Config.debug)
				Debug.Log($"MobileNotifications.ClearBadgeCounteriOS");

#if UNITY_IOS
			MobileNotifications_iOS.ClearBadgeCounter();
#endif
		}
	}
}