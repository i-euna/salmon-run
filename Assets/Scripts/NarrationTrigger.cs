using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationTrigger : MonoBehaviour
{
  public NarrativeManager manager;
  public string text;
  public bool played;

  public void ShowText()
  {
    if (!played)
    {
      Debug.Log("WOWIE TRIGGER");
      manager.ShowText(text);
      played = true;
      Invoke("Stop", 4f);
    }
  }

  private void Stop()
  {
    manager.Stop();
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    AudioManager.Instance.PlayAmbiance();
  }

}
