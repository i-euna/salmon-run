using UnityEngine;
using UnityEngine.Pool;

public class FlockController : MonoBehaviour
{
    [Header("Fish Flock Creation Variables")]
    [Tooltip("Fish Prefab")]
    [SerializeField]
    private GameObject FishPrefab;

    [Tooltip("Max no of Fish Allowed")]
    [SerializeField]
    private IntVariable MaxNoOfFish;

    [Tooltip("Max Width For Initializing The Flock")]
    [SerializeField]
    private FloatVariable MaxWidth;

    [Tooltip("Max Height For Initializing The Flock")]
    [SerializeField]
    private FloatVariable MaxHeight;

    [Header("Events")]
    [Tooltip("Game lose event")]
    [SerializeField]
    private GameEvent GameLoseEvent;

    [Tooltip("Obstacle hit event")]
    [SerializeField]
    private GameEventWithObjAndStr OnObstacleHit;

    //Fish Pool
    private ObjectPool<GameObject> FishPool;

    private void Start()
    {
        InitializeFishPool();
        ActivateAll();
        AddActionListerForEvents();
    }

    /// <summary>
    /// Initialize fish pool
    /// </summary>
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
    /// <summary>
    /// Add dynamic callback to event
    /// </summary>
    void AddActionListerForEvents() {
        OnObstacleHit.Event.AddListener(ReleaseFish);
    }

    /// <summary>
    /// Activate all fish from pool
    /// </summary>
    public void ActivateAll() {

        int max = MaxNoOfFish.Value;
        while (max > 0) {
            GameObject fish = FishPool.Get();
            fish.SetActive(true);
            Vector3 randomOffset = new Vector3(Random.Range(-MaxWidth.Value, MaxWidth.Value), Random.Range(-MaxHeight.Value, MaxHeight.Value), 0f);
            Vector3 spawnPosition = FishPrefab.transform.position + randomOffset;
            fish.transform.position = spawnPosition;
            max--;
        }
    }
    /// <summary>
    /// Release given fish to pool
    /// </summary>
    /// <param name="fish"></param>
    /// <param name="_obstacle"></param>
    public void ReleaseFish(GameObject fish, string _obstacle)
    {
        FishPool.Release(fish);
        //check remaining amount
        if (FishPool.CountActive == 0) {
            GameLoseEvent.Raise();
        }
    }
    /// <summary>
    /// Release all fish to pool
    /// </summary>
    public void ReleaseAll() {

        FishPool.Clear();
    }
}
