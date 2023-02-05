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
      float newXPosition = Random.Range(fish.transform.position.x - 1, fish.transform.position.x + 1);
      float newYPosition = Random.Range(fish.transform.position.y - 1, fish.transform.position.y + 1);
      Vector3 newPosition = new Vector3(newXPosition, newYPosition, fish.transform.position.z);
      GameObject newFish = Instantiate(fish, newPosition, fish.transform.rotation);
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
