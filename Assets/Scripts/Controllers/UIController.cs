using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("Panels")]
    [Tooltip("Game over panel")]
    [SerializeField]
    private GameObject GameOverPanel;
    [Tooltip("Game lost panel")]
    [SerializeField]
    private GameObject GameLostPanel;

    /// <summary>
    /// Activate game over panel
    /// </summary>
    public void ActivateGameOverPanel()
    {
        GameOverPanel.SetActive(true);
    }
    /// <summary>
    /// Activate game lost the panel
    /// </summary>
    public void ActivateGameLostPanel()
    {
        GameLostPanel.SetActive(true);
    }
    /// <summary>
    /// Deactivate game lost panel
    /// </summary>
    public void DeactivateGameLostPanel()
    {
        GameLostPanel.SetActive(false);
    }
}
