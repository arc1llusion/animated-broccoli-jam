using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float DistanceAllowed = 10.0f;

    private float currentDistanceTraveled = 0.0f;

    private Vector2 movementVector = Vector2.zero;

    private Vector3 lastPosition = Vector3.zero;

    private Vector3 startingPosition = Vector3.zero;

    public void AddMovementVector(Vector2 movement)
    {
        movementVector += movement;
    }

    public Vector2 ConsumeInputVector(float deltaTime, float speed)
    {
        var result = movementVector;
        movementVector = Vector2.zero;

        var deltaMove = (result * deltaTime * speed);
        var deltaDistance = Vector3.Distance(transform.position + new Vector3(deltaMove.x, deltaMove.y, 0.0f), lastPosition);        

        if (currentDistanceTraveled + deltaDistance >= DistanceAllowed)
        {
            return Vector2.zero;
        }

        currentDistanceTraveled += deltaDistance;

        return deltaMove;
    }

    public void StartMove()
    {
        startingPosition = transform.position;
        currentDistanceTraveled = 0;
    }

    public void ResetMove()
    {
        transform.position = startingPosition;
        currentDistanceTraveled = 0;
    }

    public void SetLastPosition(Vector3 lastPosition)
    {
        this.lastPosition = lastPosition;
    }

    public void ConfirmMove()
    {
        startingPosition = transform.position;
    }
}
