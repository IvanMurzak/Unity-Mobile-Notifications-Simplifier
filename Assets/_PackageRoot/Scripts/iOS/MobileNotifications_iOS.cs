#if UNITY_IOS
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using Unity.Notifications.iOS;
using UnityEngine;

namespace Extensions.Notifications
{
	public static class MobileNotifications_iOS
	{
		private static	Dictionary<string, bool>		CHANNEL_REGISTERED			= new Dictionary<string, bool>();

		public static async UniTask RequestAuthorization()
		{
			var authorizationOption = AuthorizationOption.Alert | AuthorizationOption.Badge | AuthorizationOption.Sound;
			using (var req = new AuthorizationRequest(authorizationOption, true))
			{
				while (!req.IsFinished)
				{
					await UniTask.Yield();
				};

				string res = "RequestAuthorization:";
				res += "\n finished: " + req.IsFinished;
				res += "\n granted :  " + req.Granted;
				res += "\n error:  " + req.Error;
				res += "\n deviceToken:  " + req.DeviceToken;
				Debug.Log(res);
			}
		}
		private static async UniTask RegisterNotificationChannel(string identifier, string title, string subtitle, string body, iOSNotificationTrigger trigger)
		{
			await RequestAuthorization();

			if (new iOSNotificationSettings().AuthorizationStatus != AuthorizationStatus.Authorized)
			{
				Debug.LogError("IOSNotification non authorized for schedule notification");
			}

			var unregistered = !CHANNEL_REGISTERED.ContainsKey(identifier) || !CHANNEL_REGISTERED[identifier];
			if (unregistered)
			{
				var notification = new iOSNotification()
				{
					Identifier						= identifier,
					Title							= title,
					Body							= body,
					Subtitle						= subtitle,
					ShowInForeground				= true,
					ForegroundPresentationOption	= (PresentationOption.Alert | PresentationOption.Badge | PresentationOption.Sound),
					CategoryIdentifier				= "category_a",
					ThreadIdentifier				= "thread1",
					Trigger							= trigger,
				};

				try
				{
					iOSNotificationCenter.ScheduleNotification(notification);
					CHANNEL_REGISTERED[identifier] = true;
				}
				catch(Exception e)
				{
					Debug.LogException(e);
				}
			}
		}
	
		public static void Schedule(string identifier, string title, string subtitle, string text, DateTime fireTime)
		{
			var interval = DateTime.Now - fireTime;
			if (interval <= TimeSpan.Zero)
				interval = TimeSpan.FromSeconds(1);

			var timeTrigger = new iOSNotificationTimeIntervalTrigger
			{
				TimeInterval = interval,
				Repeats = false
			};

			RegisterNotificationChannel(identifier, title, subtitle, text, timeTrigger).Forget();
		}
		public static void CancelAllScheduled()
		{
			iOSNotificationCenter.RemoveAllScheduledNotifications();
		}
	}
}
#endif