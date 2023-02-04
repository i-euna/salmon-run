using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
  public bool deadly = true;

  public void Kill()
  {
    Invoke("Stop", 0.5f);
  }

  public void Stop()
  {
    deadly = false;
  }
}
