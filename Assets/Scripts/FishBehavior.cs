using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    [SerializeField]
    private FloatVariable MovementSpeed;

    [SerializeField]
    private Vector3Variable TargetPosition;

    private float zPos;

    private FlockController controller;

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
        if (collision.collider.tag == "Obstacle") {
            Debug.Log("Die");
            controller.ReleaseFish(gameObject);
        }
    }
}
