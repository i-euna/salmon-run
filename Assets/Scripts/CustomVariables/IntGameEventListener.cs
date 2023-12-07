using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class GameIntEvent : UnityEvent<int>
{
}

public class IntGameEventListener : MonoBehaviour
{
    public GameEventWithInt IntEvent;
    public GameIntEvent OnIntEvent;

    private void OnEnable()
    {
        //Check if the event exists to avoid errors
        if (IntEvent == null)
        {
            return;
        }
        IntEvent.OnEvent += Respond;
    }

    private void OnDisable()
    {
        if (IntEvent == null)
        {
            return;
        }
        IntEvent.OnEvent -= Respond;
    }

    public void Respond(int value)
    {
        if (OnIntEvent == null)
        {
            return;
        }
        OnIntEvent.Invoke(value);
    }
}
