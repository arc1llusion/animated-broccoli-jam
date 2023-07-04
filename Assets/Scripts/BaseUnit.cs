using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseUnit : MonoBehaviour
{
    [SerializeField]
    private float Speed = 2.0f;

    [SerializeField]
    private float SprintSpeed = 5.0f;

    [SerializeField]
    protected bool DoTraditionalMovement = true;

    [SerializeField]
    protected GameObject SelectedIndicator = null;

    private Rigidbody2D rigid;

    private CinemachineVirtualCamera vc;

    protected bool IsSprinting = false;

    protected Vector2 movementVector = Vector2.zero;

    protected GameManager gameManager;

    protected Movement movement;

    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        vc = GetComponentInChildren<CinemachineVirtualCamera>(true);
        gameManager = FindFirstObjectByType<GameManager>();
        movement = GetComponent<Movement>();
    }

    protected virtual void OnEnable()
    {
        if (gameManager == null)
        {
            gameManager = FindFirstObjectByType<GameManager>();
        }
    }

    protected virtual void OnDisable()
    {
        SetUnitMovementEnabled(false);
    }

    public virtual void SetUnitMovementEnabled(bool Enable)
    {

    }

    protected virtual void FixedUpdate()
    {
        movement.AddMovementVector(movementVector);

        var moveThisTick = movement.ConsumeInputVector(Time.fixedDeltaTime, IsSprinting ? SprintSpeed : Speed);
        rigid.MovePosition(rigid.position + moveThisTick);

        movement.SetLastPosition(transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(movementVector.x, movementVector.y, 0.0f) * 10);
    }
    public CinemachineVirtualCamera GetVirtualCamera()
    {
        return vc;
    }

    public virtual void StartMove()
    {
        movement.StartMove();
    }

    public virtual void ResetMove()
    {
        movement.ResetMove();
    }

    public virtual void ConfirmMove()
    {
        movement.ConfirmMove();
    }
}
