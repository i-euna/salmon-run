using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Custom/GameEventWithObjAndStr")]
public class GameEventWithObjAndStr : ScriptableObject
{
    public UnityEvent<GameObject, string> Event;

    public void InvokeEvent(GameObject gO, string str)
    {
        Event.Invoke(gO, str);
    }
}
