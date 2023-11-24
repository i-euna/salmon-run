using UnityEngine;
using UnityEngine.Pool;

public class FlockController : MonoBehaviour
{
    [Tooltip("Fish Prefab")]
    [SerializeField]
    private GameObject FishPrefab;

    [Tooltip("Max no of Fish Allowed")]
    [SerializeField]
    private IntVariable MaxNoOfFish;

    //Fish Pool
    private ObjectPool<GameObject> FishPool;

    [Tooltip("Max Width For Initializing The Flock")]
    [SerializeField]
    private FloatVariable MaxWidth;
    [Tooltip("Max Height For Initializing The Flock")]
    [SerializeField]
    private FloatVariable MaxHeight;

    private void Start()
    {
        InitializeFishPool();
        ActivateAll();
    }

    void InitializeFishPool() {
        //Initialize the pool
        FishPool = new ObjectPool<GameObject>(() =>
        {
            GameObject newFish = Instantiate(FishPrefab);
            newFish.transform.parent = transform;
            return newFish; 
        },
        fish => { fish.SetActive(true); },
        fish => { fish.SetActive(false); },
        fish => { Destroy(fish); },
        false,
        MaxNoOfFish.Value,
        MaxNoOfFish.Value
        );
    }

    void ActivateAll() {

        int max = MaxNoOfFish.Value;
        while (max > 0) {
            GameObject fish = FishPool.Get();
            fish.SetActive(true);
            Vector3 randomOffset = new Vector3(Random.Range(-MaxWidth.Value, MaxWidth.Value), Random.Range(-MaxHeight.Value, MaxHeight.Value), 0f);
            Vector3 spawnPosition = fish.transform.position + randomOffset;
            fish.transform.position = spawnPosition;
            max--;
        }
    }

    public void ReleaseFish(GameObject fish)
    {
        FishPool.Release(fish);
    }
}
