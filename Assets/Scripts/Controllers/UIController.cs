using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOverPanel;

    [SerializeField]
    private GameObject GameLostPanel;

    public void ActivateGameOverPanel()
    {
        GameOverPanel.SetActive(true);
    }

    public void ActivateGameLostPanel()
    {
        GameLostPanel.SetActive(true);
    }

    public void DeactivateGameLostPanel()
    {
        GameLostPanel.SetActive(false);
    }
}
