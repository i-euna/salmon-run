using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Tooltip("Latest Position For Mouse")]
    [SerializeField]
    private Vector3Variable LastMousePosition;

    [Tooltip("Event to broadcast mouse movement")]
    [SerializeField]
    private GameEvent MouseMoveEvent;

    //Do not execute methods in Update on every frame
    private int interval = 2;
    void Start()
    {
        LastMousePosition.Value = Input.mousePosition;
    }

    void Update()
    {
        //if (Time.frameCount % interval == 0) 
        {
            CheckMouseMovement();
        }
    }

    void CheckMouseMovement() {
        if (Input.mousePosition != LastMousePosition.Value)
        {
            LastMousePosition.Value = Input.mousePosition;
            MouseMoveEvent.Raise();
        }
    }
}
