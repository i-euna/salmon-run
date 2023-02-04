using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraScript : MonoBehaviour
{
  public Transform player;
  public Vector3 offset;
  [Range(1, 10)]
  public float smoothFactor;
  public Vector3 minV, maxV;


  /// Awake is called when the script instance is being loaded.
  void Awake()
  {
    Vector3 targetPosition = player.position + offset;
    Vector3 bounds = new Vector3(
        Mathf.Clamp(targetPosition.x, minV.x, maxV.x),
        Mathf.Clamp(targetPosition.y, minV.y, maxV.y),
        Mathf.Clamp(targetPosition.z, minV.z, maxV.z));
    transform.position = bounds;
  }

  private void FixedUpdate()
  {

    Vector3 targetPosition = player.position;
    Vector3 bounds = new Vector3(
        Mathf.Clamp(targetPosition.x, minV.x, maxV.x),
        Mathf.Clamp(targetPosition.y, minV.y, maxV.y),
        Mathf.Clamp(-1, minV.z, maxV.z));
    Vector3 smoothPosition = Vector3.Lerp(transform.position, bounds, smoothFactor * Time.fixedDeltaTime);
    transform.position = smoothPosition;
  }
}
