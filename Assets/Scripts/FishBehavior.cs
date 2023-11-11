using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    [SerializeField]
    private FloatVariable MovementSpeed;

    [SerializeField]
    private Vector3Variable TargetPosition;

    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {

       // transform.position = Vector3.Lerp(transform.position, TargetPosition.Value, MovementSpeed.Value * Time.deltaTime);
    }
}
