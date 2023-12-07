using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Custom/GameEventWithInt")]
public class GameEventWithInt : ScriptableObject
{
    public UnityAction<int> OnEvent;

    public void InvokeEvent(int i)
    {
        if(OnEvent != null)
            OnEvent.Invoke(i);
    }
}
