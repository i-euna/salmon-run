using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
  public CameraScript cameraScript;
  private Vector2 mousePos;
  private Vector2 myPosition;

  private Vector2 movePosition = new Vector2(0f, 0f);

  public Rigidbody2D rb;
  float speed = 2f;

  [SerializeField]
  bool isPrimal;
  // Start is called before the first frame update
  void Start()
  {
    FishManager.AddFish(gameObject);
    if (isPrimal)
      cameraScript = GameObject.Find("Main Camera").GetComponent<CameraScript>();
  }

  // Update is called once per frame
  void Update()
  {
    mousePos = getPosition();
    myPosition = transform.position;
    movePosition = Vector2.Lerp(myPosition, mousePos, speed * 0.01f);
    float angle = Mathf.Atan2(myPosition.y - mousePos.y, myPosition.x - mousePos.x) * Mathf.Rad2Deg;
    // transform.position = Vector2.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
  }

  private void FixedUpdate()
  {
    rb.MovePosition(movePosition);
  }

  Vector2 getPosition()
  {
    return Camera.main.ScreenToWorldPoint(Input.mousePosition);
  }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.gameObject.tag == "Obstacle")
    {
      if (FishManager.fishes.Count < 1)
      {
        Debug.Log(FishManager.fishes.Count);
        cameraScript.player = cameraScript.mousePosition;
      }
      else
      {
        Debug.Log(FishManager.fishes.Count);
        cameraScript.player = FishManager.fishes[0].transform;
      }
      FishManager.RemoveFish(gameObject);
      Destroy(gameObject);
    }

  }
}
