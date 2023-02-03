using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

  private Vector2 mousePos;
  private float angle;
  public float speed;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    mousePos = getPosition();
    transform.position = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);

    angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
  }

  Vector2 getPosition()
  {
    return Camera.main.ScreenToWorldPoint(Input.mousePosition);
  }


}
