using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
  public static GameOverManager instance;
  public GameObject GameOverPanel;
  public Animator animator;
  public bool isGameOver = false;
  public TMP_Text signText;
  private void Start()
  {
    instance = this;
  }
  private void OnCollisionEnter2D(Collision2D collision)
  {
    signText.text = FishManager.fish_amount.ToString() + " Salmons Survived";
    GameOverPanel.SetActive(true);
    animator.SetBool("Win", true);
    isGameOver = true;

    Invoke("Pause", 5f);
  }

  public void Pause()
  {
    Time.timeScale = 0f;
  }
}
