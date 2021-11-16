![npm](https://img.shields.io/npm/v/extensions.unity.notifications)
# Unity Mobile Notifications Simplifier
Ready to use Android and iOS mobile notification solution based on official Unity Mobile Notifications package. Build on top of [Unity Mobile Notifications](https://docs.unity3d.com/Packages/com.unity.mobile.notifications@1.4/manual/index.html) package. Supported codeless usage if needed but not required.

# How to use
### Option - code
<code>MobileNotifications.Send</code> for sending notification right now.

<code>MobileNotifications.Schedule</code> for schedule notification in right moment.

### Option - codeless
Add the NotificationSender component to any object in a scene or prefab. Call the function <code>Send</code> or <code>Schedule</code> using Button component for example.

![Codeless usage](https://imgur.com/kidklV8.png)

# How to install
- Install [ODIN Inspector](https://odininspector.com/)
- Add this code to <code>/Packages/manifest.json</code>
```json
{
  "dependencies": {
    "extensions.unity.notifications": "1.0.0",
  },
  "scopedRegistries": [
    {
      "name": "Unity Extensions",
      "url": "https://registry.npmjs.org",
      "scopes": [
        "extensions.unity"
      ]
    },
    {
      "name": "NPM",
      "url": "https://registry.npmjs.org",
      "scopes": [
        "com.cysharp",
        "com.neuecc"
      ]
    }
  ]
}
