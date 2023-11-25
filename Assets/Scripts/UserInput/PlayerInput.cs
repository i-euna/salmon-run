using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Mouse Position")]
    [Tooltip("Latest Position For Mouse")]
    [SerializeField]
    private Vector3Variable LastMousePosition;

    [Header("Camera")]
    [Tooltip("Main Camera")]
    [SerializeField]
    private Camera MainCamera;

    [Header("Events")]
    [Tooltip("Event to broadcast mouse movement")]
    [SerializeField]
    private GameEvent MouseMoveEvent;

    [Header("Game State")]
    [Tooltip("Carrent Game State")]
    [SerializeField]
    private GameState GameState;

    void Start()
    {
        LastMousePosition.Value = Vector3.zero;
    }

    void Update()
    {
        if(GameState.CurrentState == GameState.State.GAME_RUNNING)
        {
            CheckMouseMovement();
        }
    }
    /// <summary>
    /// Check mouse movement
    /// Update lastest mouse position
    /// </summary>
    void CheckMouseMovement() {

        Vector3 mousePos = Input.mousePosition;
        if (Input.mousePosition != LastMousePosition.Value
           &&
           MainCamera != null &&
            mousePos.x >= 0 && mousePos.x <= Screen.width &&
            mousePos.y >= 0 && mousePos.y <= Screen.height

            )
        {
            Vector3 worldPosition = MainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mousePos.z));
            LastMousePosition.Value = worldPosition;
            MouseMoveEvent.Raise();
        }
    }
}
