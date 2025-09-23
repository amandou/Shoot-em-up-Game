using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayFromFirstScene : EditorWindow
{
    private static string PlaymodeTargetScene = "0_MainMenuScene";
    private static string CurrentScene;

    [MenuItem("Tools/Play From First Scene")]
    private static void PlayFromMainMenu()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false; 
            return;
        }
        
        if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) return;  
        
        CurrentScene = SceneManager.GetActiveScene().path;
        
        if (EditorSceneManager.OpenScene(GetScenePath(PlaymodeTargetScene), OpenSceneMode.Single).IsValid())
        {
            EditorApplication.isPlaying = true;
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }
        else
        {
            Debug.LogError("Scene not found: " + PlaymodeTargetScene);
        }
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state != PlayModeStateChange.EnteredEditMode) return;
        
        if (!string.IsNullOrEmpty(CurrentScene)) EditorSceneManager.OpenScene(CurrentScene);
        
        EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
    }

    private static string GetScenePath(string sceneName)
    {
        foreach (var scene in EditorBuildSettings.scenes)
        {
            if (scene.path.Contains(sceneName)) return scene.path;
        }
        return null;
    }
}
