using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject GameOverPanel;

    public void ActivateGameOverPanel()
    {
        GameOverPanel.SetActive(true);
    }

}
