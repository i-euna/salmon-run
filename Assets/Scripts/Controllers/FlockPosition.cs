using UnityEngine;

public class FlockPosition : MonoBehaviour
{
    [SerializeField]
    private FloatVariable MovementSpeed;

    [SerializeField]
    private Vector3Variable TargetPosition;

    private float zPos;

    private void Start()
    {
        zPos = transform.position.z;
    }

    public void MoveTowardsTarget()
    {
        Vector3 targetPosition = new Vector3(TargetPosition.Value.x,
                                            TargetPosition.Value.y,
                                            zPos);
        //move towards target
        transform.position = Vector3.Lerp(transform.position, targetPosition, MovementSpeed.Value * Time.deltaTime);
    }
}
