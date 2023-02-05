using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
  public bool deadly = true;
  public float openTime;
  public Animator animator;
  public GameObject player;

  float distance;

  public void Kill()
  {
    animator.SetBool("Attack", true);
    Invoke("Stop", openTime);
  }

  public void Stop()
  {
    animator.SetBool("Attack", false);
    deadly = false;
  }

  void FixedUpdate()
  {
    distance = Vector2.Distance(transform.position, player.transform.position);
    if (distance < 4)
    {
      animator.SetBool("In Range", true);
    }
    else
    {
      animator.SetBool("In Range", false);
    }
  }
}
