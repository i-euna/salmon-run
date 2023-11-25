using UnityEngine;

public class FlockPosition : MonoBehaviour
{
    [Header("Camera Movement")]
    [Tooltip("Camera Movement Speed")]
    [SerializeField]
    private FloatVariable MovementSpeed;
    [Tooltip("Mouse Position Holder")]
    [SerializeField]
    private Vector3Variable TargetPosition;
    [Tooltip("Movement Limiter")]
    [SerializeField]
    private float xClampValue;

    private Vector3 InitialPos;
    
    private float zPos;

    private void Start()
    {
        InitialPos = transform.position;
        zPos = transform.position.z;
    }
    /// <summary>
    /// Move camera towards target
    /// </summary>
    public void MoveTowardsTarget()
    {
        float xPos = Mathf.Clamp(TargetPosition.Value.x, -xClampValue, xClampValue);
        Vector3 targetPosition = new Vector3(xPos,
                                            TargetPosition.Value.y,
                                            zPos);
        //move towards target
        transform.position = Vector3.Lerp(transform.position, targetPosition, MovementSpeed.Value * Time.deltaTime);
    }
    /// <summary>
    /// Reset camera position
    /// </summary>
    public void Reset()
    {
        transform.position = InitialPos;
    }
}
