using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
  private Vector2 mousePos;
  private Vector2 myPosition;

  public Transform flock;

  private Vector2 movePosition = new Vector2(0f, 0f);

  public Rigidbody2D rb;
  float speed = 2f;

  private float deathDistance;
  // Start is called before the first frame update
  void Start()
  {
    deathDistance = FishManager.deathDistance;
    //float angle = Random.Range(0, 2 * Mathf.PI);
    //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
  }

  // Update is called once per frame
  void Update()
  {
    mousePos = getPosition();
    myPosition = transform.position;
    movePosition = Vector2.Lerp(myPosition, mousePos, speed * 0.007f);
    float angle = Mathf.Atan2(myPosition.y - mousePos.y, myPosition.x - mousePos.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
  }

  private void FixedUpdate()
  {
    rb.MovePosition(movePosition);
    float distance = Vector2.Distance(transform.position, flock.position);
    if (distance > deathDistance)
    {
      Debug.Log(FishManager.fish_amount);
      Die();
    }
  }

  Vector2 getPosition()
  {
    return Camera.main.ScreenToWorldPoint(Input.mousePosition);
  }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.gameObject.tag == "Obstacle")
    {
      ObstacleScript ob = col.gameObject.GetComponent<ObstacleScript>();
      if (ob.deadly)
      {
        // Debug.Log(FishManager.fish_amount);
        ob.Kill();
        Die();
      }
    }
    if (col.gameObject.tag == "Trigger")
    {
      NarrationTrigger nt = col.gameObject.GetComponent<NarrationTrigger>();
      nt.ShowText();
    }
  }

  void Die()
  {

    int index = FishCreator.instance.fishes.IndexOf(gameObject);
    if (index != -1)
      FishCreator.instance.fishes.Remove(FishCreator.instance.fishes[index]);
    Destroy(gameObject);
    FishManager.fish_amount -= 1;
  }
}
