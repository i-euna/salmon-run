using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCreator : MonoBehaviour
{

  public GameObject fish;
  public List<GameObject> fishes;

  public int fish_amount;
  // Start is called before the first frame update
  void Start()
  {
    for (int i = 0; i < fish_amount; i++)
    {
      GameObject newFish = Instantiate(fish, fish.transform.position, fish.transform.rotation);
      fishes.Add(newFish);
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
