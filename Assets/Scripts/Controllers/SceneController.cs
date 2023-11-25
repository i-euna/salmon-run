using System.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine;
public static class SceneController
{
    public enum Scene { 
        LoadingScene,
        GameScene
    }

    public static void Load(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }
}
