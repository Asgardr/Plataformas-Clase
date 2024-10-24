using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

public class ShowScenes : EditorWindow
{
    [MenuItem("Window/Show Scenes")]
    public static void Init()
    {
        // Get existing open window or if none, make a new one:
        ShowScenes window = (ShowScenes)EditorWindow.GetWindow(typeof(ShowScenes));
        window.Show();
    }
    void OnGUI()
    {
        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
        GUILayout.Label("Scenes", EditorStyles.boldLabel);
        foreach (var scene in scenes)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(scene.path, EditorStyles.boldLabel);
            if (GUILayout.Button("Open"))
            {
                EditorSceneManager.OpenScene(scene.path);
            }
            GUILayout.EndHorizontal();
        }
    }
}
