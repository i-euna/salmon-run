using UnityEngine;
using UnityEngine.UI;

public class PlayButtonAction : MonoBehaviour
{
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Play);
    }

    void Play()
    {
        SceneController.Load(SceneController.Scene.GameScene);
    }
}
