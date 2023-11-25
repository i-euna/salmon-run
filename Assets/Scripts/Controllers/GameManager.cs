using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameState GameState;

    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        GameState.CurrentState = GameState.State.GAME_RUNNING;
    }

    public void GameOver() {
        GameState.CurrentState = GameState.State.GAMEOVER;
    }

    public void GameLost()
    {
        GameState.CurrentState = GameState.State.GAME_LOST;
    }
}
