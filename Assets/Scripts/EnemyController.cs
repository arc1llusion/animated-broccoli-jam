using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class EnemyController : BaseUnit
{
    private bool moving = false;

    private readonly float[] PossibleMovementValues = new float[] { -1, 0, 1 };

    protected override void FixedUpdate()
    {
        movementVector = Vector2.zero;
        if (moving)
        {
            var x = PossibleMovementValues[UnityEngine.Random.Range(0, PossibleMovementValues.Length)];
            var y = PossibleMovementValues[UnityEngine.Random.Range(0, PossibleMovementValues.Length)];
            var input = new Vector2(x, y);

            var flattenedInput = Quaternion.Euler(30.0f, 0.0f, 0.0f) * new Vector3(input.x, 0, input.y).normalized;
            movementVector = Vector3.ProjectOnPlane(flattenedInput, Vector3.forward).normalized;
            movementVector.y = -movementVector.y;

            Debug.Log(movement.DistanceRemaining);
            if (movement.DistanceRemaining < 0.5f)
            {
                moving = false;
                base.ConfirmMove();
                gameManager.ReturnUnit(this, true);
            }
        }

        base.FixedUpdate();
    }

    public override void StartMove()
    {
        moving = true;
        base.StartMove();
    }
}
