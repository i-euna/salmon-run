using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    [SerializeField]
    private FloatVariable MovementSpeed;

    [SerializeField]
    private Vector3Variable TargetPosition;

    private float zPos;

    private FlockController controller;

    [Tooltip("Game over event")]
    [SerializeField]
    private GameEvent GameOverEvent;

    [Tooltip("Hit stone event")]
    [SerializeField]
    private GameEvent HitStoneEvent;

    [Tooltip("Hit bear event")]
    [SerializeField]
    private GameEvent HitBearEvent;

    [Tooltip("Hit fisherman event")]
    [SerializeField]
    private GameEvent HitFishermanEvent;

    [SerializeField]
    private GameEventWithArg OnObstacleHit;

    private void Start()
    {
        zPos = transform.position.z;
        controller = transform.parent.GetComponent<FlockController>();
    }

    public void MoveAndRotateTowardsTarget()
    {
        Vector3 targetPosition = new Vector3(TargetPosition.Value.x, 
                                            TargetPosition.Value.y,
                                            zPos);
        //move towards target
        transform.position = Vector3.Lerp(transform.position, targetPosition, MovementSpeed.Value * Time.deltaTime);

        //rotate towards target
        Vector3 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag) {
            case "EndPoint":
                //Game Over
                GameOverEvent.Raise();
                break;
            case "Stone":
                OnObstacleHit.InvokeEvent(gameObject);
                HitStoneEvent.Raise();
                break;
            case "Fisherman":
                Debug.Log("Hit fisherman");
                OnObstacleHit.InvokeEvent(gameObject);
                //Release to pool
                HitFishermanEvent.Raise();
                break;
            case "Bear":
                OnObstacleHit.InvokeEvent(gameObject);
                Debug.Log("Hit bear");
                HitBearEvent.Raise();
                break;
            default:
                break;
        }
    }

}
