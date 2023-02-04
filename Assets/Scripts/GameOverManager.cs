using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;
    public GameObject GameOverPanel;
    public bool isGameOver = false;
    private void Start()
    {
        instance = this;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOverPanel.SetActive(true);
        isGameOver = true;
    }
}
