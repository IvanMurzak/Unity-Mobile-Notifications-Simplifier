using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Extensions.Notifications
{
    public static class NotificationsConfigMenu
    {
        [InitializeOnLoadMethod]
        public static IEnumerator Init()
        {
            yield return null; // let's Unity initialize itself and project resources first
            GetOrCreateConfig();
        }

        [MenuItem("Edit/UnityNotifications settings...", false, 250)]
        public static void OpenOrCreateConfig()
        {
            var config = GetOrCreateConfig();

            EditorUtility.FocusProjectWindow();
            EditorWindow inspectorWindow = EditorWindow.GetWindow(typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.InspectorWindow"));
            inspectorWindow.Focus();

            Selection.activeObject = config;
        }

        public static NotificationsConfig GetOrCreateConfig()
        {
            var config = Resources.Load<NotificationsConfig>(NotificationsConfig.PATH_FOR_RESOURCES_LOAD);
            if (config == null)
            {
                Debug.Log($"<color=orange><b>Creating NotificationsConfig file</b> at <i>{NotificationsConfig.PATH}</i></color>");
                config = ScriptableObject.CreateInstance<NotificationsConfig>();

                string directory = Path.GetDirectoryName(NotificationsConfig.PATH);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                AssetDatabase.CreateAsset(config, NotificationsConfig.PATH);
                AssetDatabase.SaveAssets();
            }
            return config;
        }
    }
}