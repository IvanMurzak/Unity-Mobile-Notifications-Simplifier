using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Extensions.Notifications
{
    public class NotificationSender : SerializedMonoBehaviour
    {
        [BoxGroup("B", false), HorizontalGroup("B/H")]
        [TitleGroup("B/H/Customization")]               public string   channel             = "channel";
        [TitleGroup("B/H/Customization")]               public string   title               = "My Title";
        [TitleGroup("B/H/Customization"), TextArea]     public string   text                = "Some description text, bla-bla-bla! This is demo text.";
        [FoldoutGroup("B/H/Customization/Optional")]    public string   largeIcon           = "";
        [FoldoutGroup("B/H/Customization/Optional")]    public string   channelName         = "";
        [FoldoutGroup("B/H/Customization/Optional")]    public string   channelDescription  = "";
        [FoldoutGroup("B/H/Customization/Optional")]    public string   smallIcon           = "";

        [HorizontalGroup("B/H2")]
        [TitleGroup("B/H2/Schedule")]                   public float    offsetSeconds       = 5;


        [Button(ButtonSizes.Medium), HorizontalGroup("Buttons")]
        public void Send()
        {
            MobileNotifications.Send(channel, title, text, largeIcon, channelName, channelDescription, smallIcon);
        }
        [Button(ButtonSizes.Medium), HorizontalGroup("Buttons")]
        public void Schedule()
        {
            MobileNotifications.Schedule(channel, title, text, TimeSpan.FromSeconds(offsetSeconds), largeIcon, channelName, channelDescription, smallIcon);
        }
    }
}