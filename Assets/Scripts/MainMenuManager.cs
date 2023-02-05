using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

  public GameObject creditsPanel;

  public void ShowCredits()
  {
    creditsPanel.SetActive(true);
  }

  public void HideCredits()
  {
    creditsPanel.SetActive(false);
  }

  public void QuitGame()
  {
    Debug.Log("Quitting the game");
    Application.Quit();
  }
}
