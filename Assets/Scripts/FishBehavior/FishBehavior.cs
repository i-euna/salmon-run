using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    [SerializeField]
    private FloatVariable MovementSpeed;

    [SerializeField]
    private Vector3Variable TargetPosition;

    private float zPos;

    [Tooltip("Game over event")]
    [SerializeField]
    private GameEvent GameOverEvent;

    [Tooltip("Hit obstacle event")]
    [SerializeField]
    private GameEventWithArg OnObstacleHit;

    private void Start()
    {
        zPos = transform.position.z;
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
            case ObstacleNames.ENDPOINT:
                //Game Over
                GameOverEvent.Raise();
                break;
            case ObstacleNames.STONE:
                OnObstacleHit.InvokeEvent(gameObject, ObstacleNames.STONE);
                break;
            case ObstacleNames.FISHERMAN:
                OnObstacleHit.InvokeEvent(gameObject, ObstacleNames.FISHERMAN);
                break;
            case ObstacleNames.BEAR:
                OnObstacleHit.InvokeEvent(gameObject, ObstacleNames.BEAR);
                break;
            default:
                break;
        }
    }

}


