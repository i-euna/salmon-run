using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalmonScript : MonoBehaviour
{

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    transform.rotation = transform.parent.rotation;
    transform.position = Vector3.MoveTowards(transform.position, transform.parent.position, 2 * Time.deltaTime);
  }
}
