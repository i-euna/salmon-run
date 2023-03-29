using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
  /*
   * Bear = 0
   * HumanMadeWaste = 1
   * Log = 2
   * Seagull = 3
   * Stone = 4
   */
  public int ObstacleType;
  private void OnCollisionStay2D(Collision2D collision)
  {
    if (AudioManager.Instance != null && collision.contactCount > 1)
      AudioManager.Instance.PlayEffect(ObstacleType);
  }

}
