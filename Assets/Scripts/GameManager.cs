using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;


public enum BattleTeamTurn
{
    Player = 0,
    Enemy = 1
}

public class GameManager : MonoBehaviour, PlayerActions.ISelectionActions
{
    List<BaseUnit> playerUnits;
    private int SelectedUnit = 0;

    List<BaseUnit> enemyUnits;
    private int SelectedEnemyUnit = 0;

    private int VirtualCameraInactivePriority = 0;
    private int VirtualCameraActivePriority = 10;

    private Vector2 MousePosition = Vector2.zero;

    [SerializeField]
    LayerMask PlayerLayer;

    [SerializeField]
    CinemachineVirtualCamera PanningCamera;

    private PlayerInput playerInput = null;

    private Vector2 PanningCameraTranslate = Vector2.zero;

    private float CameraPanSpeed = 4.0f;

    private BattleTeamTurn BattleTeamTurn = BattleTeamTurn.Player;
    private List<BaseUnit> UnitTurnTaken = new List<BaseUnit>();

    private void Start()
    {
        playerUnits = FindObjectsByType<PlayerController>(FindObjectsInactive.Exclude, FindObjectsSortMode.InstanceID).Select(x => (BaseUnit)x).ToList();
        enemyUnits = FindObjectsByType<EnemyController>(FindObjectsInactive.Exclude, FindObjectsSortMode.InstanceID).Select(x => (BaseUnit)x).ToList();

        if (!PanningCamera)
        {
            Debug.LogError("No main panning camera set.");
            return;
        }

        PanningCamera.Priority = VirtualCameraActivePriority;
        DeprioritizeAllUnitCameras();
    }

    private void OnEnable()
    {
        if (playerInput == null)
        {
            playerInput = GetComponent<PlayerInput>();
        }

        SetOverviewControlsEnabled(true);
    }

    private void OnDisable()
    {
        SetOverviewControlsEnabled(false);
    }

    private void LateUpdate()
    {
        PanningCamera.transform.Translate(PanningCameraTranslate * Time.deltaTime * CameraPanSpeed, Space.Self);
    }

    public void SetOverviewControlsEnabled(bool Enable)
    {
        if (playerInput == null)
        {
            return;
        }

        if (Enable)
        {
            PlayerInputBinder.BindPlayerInputToClass(playerInput, typeof(PlayerActions), this);
            playerInput.SwitchCurrentActionMap(nameof(PlayerActions.Selection));
        }
        else
        {
            PlayerInputBinder.UnbindPlayerInputToClass(playerInput, typeof(PlayerActions), this);
        }
    }

    public void OnMoveCamera(InputAction.CallbackContext context)
    {
        if (BattleTeamTurn == BattleTeamTurn.Enemy)
            return;

        var input = context.ReadValue<Vector2>();

        PanningCameraTranslate = input;

        if (PanningCamera && PanningCamera.Priority == VirtualCameraInactivePriority)
        {
            PanningCamera.Priority = VirtualCameraActivePriority;

            var vc = GetSelectedUnitVirtualCamera();
            if (vc)
            {
                PanningCamera.ForceCameraPosition(vc.transform.position, vc.transform.rotation);
            }
        }

        DeprioritizeAllUnitCameras();
    }

    public void OnQuickSelect(InputAction.CallbackContext context)
    {
        if (playerUnits.Count() == 0 || !context.performed || BattleTeamTurn == BattleTeamTurn.Enemy)
        {
            return;
        }

        var input = context.ReadValue<float>();

        CycleSelectedUnitIndex(input);
        QuickSelectUnit();
    }

    private void CycleSelectedUnitIndex(float input)
    {
        if (input > 0)
        {
            SelectedUnit = (SelectedUnit + 1) % playerUnits.Count();
        }
        else if (input < 0)
        {
            --SelectedUnit;
            if (SelectedUnit < 0)
            {
                SelectedUnit = playerUnits.Count() - 1;
            }
        }
    }

    private void QuickSelectUnit()
    {
        for (var i = 0; i < playerUnits.Count(); ++i)
        {
            var unit = playerUnits.ElementAt(i);
            var vc = unit.GetVirtualCamera();

            if (i == SelectedUnit && vc)
            {
                vc.Priority = VirtualCameraActivePriority;
                if (PanningCamera)
                {
                    PanningCamera.Priority = VirtualCameraInactivePriority;
                }
            }
            else
            {
                vc.Priority = VirtualCameraInactivePriority;
            }
        }
    }

    public void OnSelectUnit(InputAction.CallbackContext context)
    {
        if (BattleTeamTurn == BattleTeamTurn.Player && context.performed)
        {
            SelectUnit();
        }
    }

    private CinemachineVirtualCamera GetSelectedUnitVirtualCamera()
    {
        if (SelectedUnit < 0 || SelectedUnit >= playerUnits.Count())
            return null;

        return playerUnits[SelectedUnit].GetVirtualCamera();
    }

    private void SelectUnit()
    {
        var selectedIdx = 0;
        List<BaseUnit> unitsToCheck;

        if (BattleTeamTurn == BattleTeamTurn.Player)
        {
            selectedIdx = SelectedUnit;
            unitsToCheck = playerUnits;
        }
        else
        {
            selectedIdx = SelectedEnemyUnit;
            unitsToCheck = enemyUnits;
        }

        if (UnitTurnTaken.Contains(unitsToCheck.ElementAt(selectedIdx)))
            return;

        SetOverviewControlsEnabled(false);

        for (var i = 0; i < unitsToCheck.Count(); ++i)
        {
            var unit = unitsToCheck.ElementAt(i);
            var vc = unit.GetVirtualCamera();

            if (vc)
            {
                if (i == selectedIdx)
                {
                    vc.Priority = VirtualCameraActivePriority;
                    unit.SetUnitMovementEnabled(true);
                    unit.StartMove();

                    if (PanningCamera)
                    {
                        PanningCamera.Priority = VirtualCameraInactivePriority;
                    }
                }
                else
                {
                    vc.Priority = VirtualCameraInactivePriority;
                    unit.SetUnitMovementEnabled(false);
                }
            }
        }
    }

    public void ReturnUnit(BaseUnit unit, bool turnTaken)
    {
        SetOverviewControlsEnabled(true);

        if (unit)
        {
            unit.SetUnitMovementEnabled(false);

            if (!turnTaken)
            {
                unit.ResetMove();
            }
            else
            {
                UnitTurnTaken.Add(unit);
            }

            if (BattleTeamTurn == BattleTeamTurn.Player)
            {
                var vc = unit.GetVirtualCamera();
                if (vc)
                {
                    vc.Priority = VirtualCameraInactivePriority;

                    if (PanningCamera)
                    {
                        PanningCamera.Priority = VirtualCameraActivePriority;
                        PanningCamera.ForceCameraPosition(vc.transform.position, vc.transform.rotation);
                    }
                }
            }
            else if (BattleTeamTurn == BattleTeamTurn.Enemy)
            {
                ++SelectedEnemyUnit;
                if (SelectedEnemyUnit < enemyUnits.Count())
                {
                    enemyUnits[SelectedEnemyUnit].StartMove();
                    SelectUnit();
                }
            }
        }

        CheckTurn();
    }

    public void OnQueryUnit(InputAction.CallbackContext context)
    {
        if (BattleTeamTurn == BattleTeamTurn.Player && context.performed)
        {
            var hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(MousePosition), PlayerLayer);

            if (hit)
            {
                var unit = hit.gameObject.GetComponentInParent<PlayerController>();
                if (unit)
                {
                    SelectedUnit = playerUnits.IndexOf(unit);
                    SelectUnit();
                }
            }
        }
    }

    public void OnCursorUpdate(InputAction.CallbackContext context)
    {
        MousePosition = context.ReadValue<Vector2>();
    }

    private void DeprioritizeAllUnitCameras()
    {
        for (var i = 0; i < playerUnits.Count(); ++i)
        {
            var unit = playerUnits.ElementAt(i);
            var vc = unit.GetVirtualCamera();

            if (vc)
            {
                vc.Priority = VirtualCameraInactivePriority;
            }
        }

        for (var i = 0; i < enemyUnits.Count(); ++i)
        {
            var unit = enemyUnits.ElementAt(i);
            var vc = unit.GetVirtualCamera();

            if (vc)
            {
                vc.Priority = VirtualCameraInactivePriority;
            }
        }
    }

    private void CheckTurn()
    {
        BaseUnit unitToFocus = null;
        if (BattleTeamTurn == BattleTeamTurn.Player && UnitTurnTaken.Count() == playerUnits.Count())
        {
            BattleTeamTurn = BattleTeamTurn.Enemy;
            SelectedEnemyUnit = 0;
            unitToFocus = enemyUnits[SelectedEnemyUnit];
            UnitTurnTaken.Clear();

            DeprioritizeAllUnitCameras();

            SelectUnit();
        }
        else if (BattleTeamTurn == BattleTeamTurn.Enemy && UnitTurnTaken.Count() == enemyUnits.Count())
        {
            BattleTeamTurn = BattleTeamTurn.Player;
            SelectedUnit = 0;
            unitToFocus = playerUnits[SelectedUnit];
            UnitTurnTaken.Clear();

            DeprioritizeAllUnitCameras();

            PanningCamera.Priority = VirtualCameraActivePriority;

            var vc = unitToFocus.GetVirtualCamera();
            if (vc)
            {
                PanningCamera.ForceCameraPosition(vc.transform.position, vc.transform.rotation);
            }
        }
    }

    private void OnDrawGizmos()
    {
    }
}
