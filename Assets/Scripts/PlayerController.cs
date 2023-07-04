using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;


[RequireComponent(typeof(Movement))]
public class PlayerController : MonoBehaviour, PlayerActions.IUnitActions
{
    PlayerActions controls;

    [SerializeField]
    private float Speed = 2.0f;

    [SerializeField]
    private float SprintSpeed = 5.0f;

    [SerializeField]
    private bool DoTraditionalMovement = true;

    [SerializeField]
    private GameObject SelectedIndicator = null;

    private bool IsSprinting = false;

    private Vector2 movementVector = Vector2.zero;

    private Rigidbody2D rigid;

    private CinemachineVirtualCamera vc;

    private GameManager gameManager;

    private Movement movement;

    private PlayerInput playerInput;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        vc = GetComponentInChildren<CinemachineVirtualCamera>(true);
        gameManager = FindFirstObjectByType<GameManager>();
        movement = GetComponent<Movement>();
    }

    private void OnEnable()
    {
        if(gameManager == null)
        {
            gameManager = FindFirstObjectByType<GameManager>();
        }

        if (playerInput == null)
        {
            playerInput = gameManager.GetComponent<PlayerInput>();
        }
    }

    public void SetUnitMovementEnabled(bool Enable)
    {
        if (playerInput == null)
            return;

        if(Enable)
        {
            //controls = new PlayerActions();
            //controls.Unit.AddCallbacks(this);
            //controls.Enable();
            PlayerInputBinder.BindPlayerInputToClass(playerInput, typeof(PlayerActions), this);
            playerInput.SwitchCurrentActionMap(nameof(PlayerActions.Unit));

            if (SelectedIndicator)
            {
                SelectedIndicator.SetActive(true);
            }
        }
        else
        {
            //if (controls != null)
            //{
            //    controls.Disable();
            //    controls.Unit.RemoveCallbacks(this);
            //    controls = null;
            //}
            PlayerInputBinder.UnbindPlayerInputToClass(playerInput, typeof(PlayerActions), this);

            if (SelectedIndicator)
            {
                SelectedIndicator.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        SetUnitMovementEnabled(false);
    }

    private void FixedUpdate()
    {
        movement.AddMovementVector(movementVector);

        var moveThisTick = movement.ConsumeInputVector(Time.fixedDeltaTime, IsSprinting ? SprintSpeed : Speed);
        rigid.MovePosition(rigid.position + moveThisTick);

        movement.SetLastPosition(transform.position);
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
                gameManager.ReturnUnit(this);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(movementVector.x, movementVector.y, 0.0f) * 10);
    }

    public CinemachineVirtualCamera GetVirtualCamera()
    {
        return vc;
    }

    public void StartMove()
    {
        movement.StartMove();
    }

    public void ResetMove()
    {
        movement.ResetMove();
    }

    public void ConfirmMove()
    {
        movement.ConfirmMove();
    }

    public void OnConfirm(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movement.ConfirmMove();

            if (gameManager)
            {
                gameManager.ReturnUnit(this);
            }
        }
    }
}
