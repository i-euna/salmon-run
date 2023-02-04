using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LossScript : MonoBehaviour
{
  public void Lose()
  {
    gameObject.SetActive(true);
    Invoke("Pause", 2f);
  }

  public void Pause()
  {
    Time.timeScale = 0f;
  }

  public void TryAgain()
  {
    Debug.Log("HEEEY");
    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    gameObject.SetActive(false);
  }
}
