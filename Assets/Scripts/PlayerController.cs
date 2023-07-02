using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour, PlayerActions.ITestingActions
{
    PlayerActions controls;

    [SerializeField]
    private float Speed = 2.0f;

    [SerializeField]
    private float SprintSpeed = 5.0f;

    [SerializeField]
    private bool DoTraditionalMovement = true;

    private bool IsSprinting = false;

    private Vector2 movementVector = Vector2.zero;

    private void OnEnable()
    {
        controls = new PlayerActions();
        controls.Testing.AddCallbacks(this);
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
        controls.Testing.RemoveCallbacks(this);
        controls = null;
    }

    private void Update()
    {
        transform.Translate(movementVector * (IsSprinting ? SprintSpeed : Speed) * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        var magnitude = input.magnitude;

        if (DoTraditionalMovement)
        {
            var flattenedInput =  Quaternion.Euler(30.0f, 0.0f, 0.0f) * new Vector3(input.x, 0, input.y).normalized;
            movementVector = Vector3.ProjectOnPlane(flattenedInput, Vector3.forward).normalized;
            movementVector.y = -movementVector.y;
        }
        else
        {
            var xmovement = new Vector2(input.x, 0);
            var ymovement = new Vector2(0, input.y);

            var xrotation = Quaternion.AngleAxis(-30, transform.forward) * xmovement;
            var yrotation = Quaternion.AngleAxis(-60, transform.forward) * ymovement;

            movementVector = xrotation + yrotation;
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            IsSprinting = !IsSprinting;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(movementVector.x, movementVector.y, 0.0f) * 10);
    }
}
