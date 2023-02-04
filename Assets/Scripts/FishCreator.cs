using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCreator : MonoBehaviour
{

  public CameraScript cameraScript;
  public GameObject fish;

  public LossScript loss;

  public int fish_amount;
  // Start is called before the first frame update
  void Start()
  {
    cameraScript = GameObject.Find("Main Camera").GetComponent<CameraScript>();
    FishManager.fish_amount = fish_amount + 1;
    for (int i = 0; i < fish_amount; i++)
    {
      GameObject newFish = Instantiate(fish, fish.transform.position, fish.transform.rotation);
      newFish.GetComponent<FlockManager>().cameraScript = cameraScript;
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (FishManager.fish_amount == 0)
    {
      loss.Lose();
    }
  }

}
