using UnityEngine;

[CreateAssetMenu(menuName = "Custom/GameState")]
public class GameState : ScriptableObject
{
    public enum State { 
        GAMEOVER, GAME_LOST, GAME_RUNNING, GAME_LOADING
    }

    public State CurrentState;
}
