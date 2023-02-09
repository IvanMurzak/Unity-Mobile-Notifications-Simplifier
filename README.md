# Unity Mobile Notifications Simplifier
![npm](https://img.shields.io/npm/v/extensions.unity.notifications) [![openupm](https://img.shields.io/npm/v/extensions.unity.notifications?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/extensions.unity.notifications/) ![License](https://img.shields.io/github/license/IvanMurzak/Unity-Mobile-Notifications-Simplifier) [![Stand With Ukraine](https://raw.githubusercontent.com/vshymanskyy/StandWithUkraine/main/badges/StandWithUkraine.svg)](https://stand-with-ukraine.pp.ua)

Ready to use Android and iOS mobile notification solution based on official Unity Mobile Notifications package. Build on top of [Unity Mobile Notifications](https://docs.unity3d.com/Packages/com.unity.mobile.notifications@1.4/manual/index.html) package. Supported codeless usage if needed but not required.

![Config](https://imgur.com/ITn5XUD.png)

# How to use
### Option - code
- <code>MobileNotifications.Send</code> for sending notification right now.
- <code>MobileNotifications.Schedule</code> for schedule notification in right moment.

### Option - codeless
Add the NotificationSender component to any object in a scene or prefab. Call the function <code>Send</code> or <code>Schedule</code> using Button component for example.

![Codeless usage](https://imgur.com/kidklV8.png)

# How to install - Option 1 (RECOMMENDED)
- Install [ODIN Inspector](https://odininspector.com/)
- Install [OpenUPM-CLI](https://github.com/openupm/openupm-cli#installation)
- Open command line in Unity project folder
- `openupm add extensions.unity.notifications`

# How to install - Option 2
- Install [ODIN Inspector](https://odininspector.com/)
- Add this code to <code>/Packages/manifest.json</code>
```json
{
  "dependencies": {
    "extensions.unity.notifications": "2.0.2",
  },
  "scopedRegistries": [
    {
      "name": "package.openupm.com",
      "url": "https://package.openupm.com",
      "scopes": [
        "extensions.unity"
        "com.cysharp",
        "com.neuecc"
      ]
    }
  ]
}
