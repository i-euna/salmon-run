using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FishManager
{

  public static int fish_amount;

  public static List<GameObject> fishes = new List<GameObject>();
  // Start is called before the first frame update
  public static void AddFish(GameObject newFish)
  {
    fishes.Add(newFish);
  }

  public static void RemoveFish(GameObject fish)
  {
    fish_amount -= 1;
    fishes.Remove(fish);
  }

}
