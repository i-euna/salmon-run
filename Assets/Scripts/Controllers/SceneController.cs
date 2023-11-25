using UnityEngine.SceneManagement;
public static class SceneController
{
    //game scenes
    public enum Scene { 
        LoadingScene,
        GameScene
    }

    /// <summary>
    /// load given scene
    /// </summary>
    /// <param name="scene"></param>
    public static void Load(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }
}
