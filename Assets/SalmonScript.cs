using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalmonScript : MonoBehaviour
{
  public GameObject flock;
  // Start is called before the first frame update
  void Start()
  {
    transform.parent = null;
  }

  // Update is called once per frame
  void Update()
  {
    transform.rotation = flock.transform.rotation;
    transform.position = Vector3.MoveTowards(transform.position, flock.transform.position, 2 * Time.deltaTime);
  }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.gameObject.tag == "Obstacle")
    {
      Destroy(this);
    }

  }

}
