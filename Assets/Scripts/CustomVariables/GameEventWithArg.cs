using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Custom/GameEventWithArg")]
public class GameEventWithArg : ScriptableObject
{
    public UnityEvent<GameObject, string> Event;

    public void InvokeEvent(GameObject gO, string str)
    {
        Event.Invoke(gO, str);
    }
}
