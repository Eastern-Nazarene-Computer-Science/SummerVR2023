
using UnityEngine;

public class ObjectAnimation : MonoBehaviour
{
    public float speed = 1f;  // Speed of the object's movement
    public Vector3 targetPosition;  // Target position for the object to move towards

    private Vector3 initialPosition;  // Initial position of the object
    private bool movingToTarget;  // Flag to indicate if the object is moving towards the target

    private void Start()
    {
        initialPosition = transform.position;
        movingToTarget = false;
    }

    private void Update()
    {
        if (movingToTarget)
        {
            // Move the object towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // If the object reaches the target position, stop moving
            if (transform.position == targetPosition)
            {
                movingToTarget = false;
            }
        }
    }

    public void MoveToTarget()
    {
        // Set the object's current position as the initial position
        initialPosition = transform.position;

        // Start moving the object towards the target position
        movingToTarget = true;
    }

    public void ResetPosition()
    {
        // Reset the object's position to the initial position
        transform.position = initialPosition;

        // Stop moving towards the target position
        movingToTarget = false;
    }
}
