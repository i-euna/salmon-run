using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Custom/GameEventWithInt")]
public class GameEventWithInt : ScriptableObject
{
    public UnityAction<int> OnEvent;

    public void InvokeEvent(int i)
    {
        Debug.Log("Event raised");
        if(OnEvent != null)
            OnEvent.Invoke(i);
    }
}
