using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    [Header("Fish Movement")]
    [Tooltip("Fish Movement Speed")]
    [SerializeField]
    private FloatVariable MovementSpeed;
    [Tooltip("Mouse Position Holder")]
    [SerializeField]
    private Vector3Variable TargetPosition;

    [Header("Events")]
    [Tooltip("Game over event")]
    [SerializeField]
    private GameEvent GameOverEvent;

    [Tooltip("Hit obstacle event")]
    [SerializeField]
    private GameEvent OnObstacleHit;

    private float zPos;

    private void Start()
    {
        zPos = transform.position.z;
    }
    /// <summary>
    /// Move and rotate object towards target
    /// </summary>
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
        switch (collision.collider.tag)
        {
            case ObstacleNames.ENDPOINT:
                //Game Over
                GameOverEvent.Raise();
                break;
            case ObstacleNames.STONE:
                break;
            case ObstacleNames.FISHERMAN:
            case ObstacleNames.BEAR:
                DeathRow.FishDeathRow.Enqueue(gameObject);
                OnObstacleHit.Raise();
                break;
            default:
                break;
        }
    }

}


