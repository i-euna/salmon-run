using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCreator : MonoBehaviour
{
  public static FishCreator instance;

  public GameObject fish;
  public List<GameObject> fishes;
  public LossScript loss;

  public int fish_amount;
  // Start is called before the first frame update
  void Start()
  {
        instance = this;
    FishManager.fish_amount = fish_amount + 1;
    for (int i = 0; i < fish_amount; i++)
    {
      GameObject newFish = Instantiate(fish, fish.transform.position, fish.transform.rotation);
      newFish.GetComponent<FlockManager>().flock = gameObject.transform;
      fishes.Add(newFish);
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
