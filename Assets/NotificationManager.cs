using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : Singleton<NotificationManager>
{
    string channelId = "channel_id";

    // Start is called before the first frame update
    void Start()
    {

        AndroidNotificationCenter.CancelAllScheduledNotifications();
        var channel = new AndroidNotificationChannel()
        {
            Id = channelId,
            Name = "Rightate Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        var notification = new AndroidNotification
        {
            Title = "What time is it?😈",
            Text = "It's retrowave time!",
            FireTime = System.DateTime.Now.AddDays(2),
            LargeIcon = "icon_large",
            RepeatInterval = System.TimeSpan.FromDays(2)
        };

        AndroidNotificationCenter.SendNotification(notification, channelId);
    }
}
