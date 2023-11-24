using UnityEngine;

public class FlockPosition : MonoBehaviour
{
    [SerializeField]
    private FloatVariable MovementSpeed;

    [SerializeField]
    private Vector3Variable TargetPosition;

    private float zPos;

    [SerializeField]
    private float xClampValue;

    private Vector3 InitialPos;

    private void Start()
    {
        InitialPos = transform.position;
        zPos = transform.position.z;
    }

    public void MoveTowardsTarget()
    {
        float xPos = Mathf.Clamp(TargetPosition.Value.x, -xClampValue, xClampValue);
        Vector3 targetPosition = new Vector3(xPos,
                                            TargetPosition.Value.y,
                                            zPos);
        //move towards target
        transform.position = Vector3.Lerp(transform.position, targetPosition, MovementSpeed.Value * Time.deltaTime);
    }

    public void Reset()
    {
        transform.position = InitialPos;
    }
}
