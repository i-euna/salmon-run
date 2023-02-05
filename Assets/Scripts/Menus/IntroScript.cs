using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    Invoke("Off", 8f);
  }

  void Off()
  {
    Destroy(gameObject);
  }
}
