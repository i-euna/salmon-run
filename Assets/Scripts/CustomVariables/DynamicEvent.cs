using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Custom/DynamicEvent")]
public class DynamicEvent : ScriptableObject
{
    public UnityEvent<GameObject> Event;

    public void InvokeEvent(GameObject gO)
    {
        Event.Invoke(gO);
    }
}
