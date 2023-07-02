using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour, PlayerActions.ISelectionActions
{
    PlayerActions controls;

    IEnumerable<PlayerController> units;
    private int SelectedUnit = 0;

    private int VirtualCameraInactivePriority = 0;
    private int VirtualCameraActivePriority = 10;

    private void Start()
    {
        units = FindObjectsByType<PlayerController>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

        Debug.Log("Unit count: " + units.Count());
    }

    private void OnEnable()
    {
        SetOverviewControlsEnabled(true);
    }

    private void OnDisable()
    {
        SetOverviewControlsEnabled(false);
    }

    public void SetOverviewControlsEnabled(bool Enable)
    {
        if (Enable)
        {
            controls = new PlayerActions();
            controls.Selection.AddCallbacks(this);
            controls.Enable();
        }
        else
        {
            if (controls != null)
            {
                controls.Disable();
                controls.Selection.RemoveCallbacks(this);
                controls = null;
            }
        }
    }

    public void OnMoveCamera(InputAction.CallbackContext context)
    {
    }

    public void OnQuickSelect(InputAction.CallbackContext context)
    {
        if(units.Count() == 0 || !context.performed)
        {
            return;
        }

        var input = context.ReadValue<float>();

        if (input > 0)
        {
            SelectedUnit = (SelectedUnit + 1) % units.Count();
        }
        else if(input < 0)
        {
            --SelectedUnit;
            if(SelectedUnit < 0)
            {
                SelectedUnit = units.Count() - 1;
            }
        }


        for(var i = 0; i < units.Count(); ++i)
        {
            var unit = units.ElementAt(i);
            var vc = unit.GetVirtualCamera();

            if (vc)
            {
                if (i == SelectedUnit)
                {
                    vc.Priority = VirtualCameraActivePriority;
                }
                else
                {
                    vc.Priority = VirtualCameraInactivePriority;
                }
            }
        }
    }

    public void OnSelectUnit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SetOverviewControlsEnabled(false);

            for (var i = 0; i < units.Count(); ++i)
            {
                var unit = units.ElementAt(i);

                if (i == SelectedUnit)
                {
                    unit.SetUnitMovementEnabled(true);
                }
                else
                {
                    unit.SetUnitMovementEnabled(false);
                }
            }
        }
    }

    public void ReturnUnit(PlayerController player)
    {
        SetOverviewControlsEnabled(true);

        if (player)
        {
            player.SetUnitMovementEnabled(false);    
        }
    }
}
