using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Custom/GameEventWithArg")]
public class GameEventWithArg : ScriptableObject
{
    public UnityEvent<GameObject> Event;

    public void InvokeEvent(GameObject gO)
    {
        Event.Invoke(gO);
    }
}
