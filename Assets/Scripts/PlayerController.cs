using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;


[RequireComponent(typeof(Movement))]
public class PlayerController : BaseUnit, PlayerActions.IUnitActions
{
    private PlayerInput playerInput;

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        if (playerInput == null)
        {
            playerInput = gameManager.GetComponent<PlayerInput>();
        }
    }

    public override void SetUnitMovementEnabled(bool Enable)
    {
        base.SetUnitMovementEnabled(Enable);

        if (playerInput == null)
            return;

        if(Enable)
        {
            PlayerInputBinder.BindPlayerInputToClass(playerInput, typeof(PlayerActions), this);
            playerInput.SwitchCurrentActionMap(nameof(PlayerActions.Unit));

            if (SelectedIndicator)
            {
                SelectedIndicator.SetActive(true);
            }
        }
        else
        {
            PlayerInputBinder.UnbindPlayerInputToClass(playerInput, typeof(PlayerActions), this);

            if (SelectedIndicator)
            {
                SelectedIndicator.SetActive(false);
            }
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();

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

    public void OnGoBack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (gameManager)
            {
                gameManager.ReturnUnit(this, false);
            }
        }
    }

    public void OnConfirm(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movement.ConfirmMove();

            if (gameManager)
            {
                gameManager.ReturnUnit(this, true);
            }
        }
    }
}
