using UnityEngine;
using UnityEngine.UI;

public class PlayAgainButtonAction : MonoBehaviour
{
    private Button button;

    [Tooltip("Game reset event")]
    [SerializeField]
    private GameEvent GameResetEvent;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PlayAgain);
    }

    private void PlayAgain() {
        GameResetEvent.Raise();
    }
}
