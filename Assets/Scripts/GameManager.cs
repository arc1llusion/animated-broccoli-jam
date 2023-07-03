using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class GameManager : MonoBehaviour, PlayerActions.ISelectionActions
{
    PlayerActions controls;

    List<PlayerController> units;
    private int SelectedUnit = 0;

    private int VirtualCameraInactivePriority = 0;
    private int VirtualCameraActivePriority = 10;

    private Vector2 MousePosition = Vector2.zero;

    [SerializeField]
    LayerMask PlayerLayer;

    [SerializeField]
    CinemachineVirtualCamera PanningCamera;

    private Vector2 PanningCameraTranslate = Vector2.zero;

    private float CameraPanSpeed = 4.0f;

    private void Start()
    {
        units = FindObjectsByType<PlayerController>(FindObjectsInactive.Exclude, FindObjectsSortMode.None).ToList();

        if(!PanningCamera)
        {
            Debug.LogError("No main panning camera set.");
            return;
        }

        PanningCamera.Priority = VirtualCameraActivePriority;
        DeprioritizeAllUnitCameras();
    }

    private void OnEnable()
    {
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
        var input = context.ReadValue<Vector2>();

        PanningCameraTranslate = input;

        if (PanningCamera && PanningCamera.Priority == VirtualCameraInactivePriority)
        {
            PanningCamera.Priority = VirtualCameraActivePriority;

            var vc = GetSelectedUnitVirtualCamera();
            if(vc)
            {
                PanningCamera.ForceCameraPosition(vc.transform.position, vc.transform.rotation);
            }     
        }

        DeprioritizeAllUnitCameras();
    }

    public void OnQuickSelect(InputAction.CallbackContext context)
    {
        if (units.Count() == 0 || !context.performed)
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
            SelectedUnit = (SelectedUnit + 1) % units.Count();
        }
        else if (input < 0)
        {
            --SelectedUnit;
            if (SelectedUnit < 0)
            {
                SelectedUnit = units.Count() - 1;
            }
        }
    }

    private void QuickSelectUnit()
    {
        for (var i = 0; i < units.Count(); ++i)
        {
            var unit = units.ElementAt(i);
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
        if (context.performed)
        {
            SelectUnit();
        }
    }

    private CinemachineVirtualCamera GetSelectedUnitVirtualCamera()
    {
        if (SelectedUnit < 0 || SelectedUnit >= units.Count())
            return null;

        return units[SelectedUnit].GetVirtualCamera();
    }

    private void SelectUnit()
    {
        SetOverviewControlsEnabled(false);        

        for (var i = 0; i < units.Count(); ++i)
        {
            var unit = units.ElementAt(i);
            var vc = unit.GetVirtualCamera();

            if (vc)
            {
                if (i == SelectedUnit)
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

    public void ReturnUnit(PlayerController player)
    {
        SetOverviewControlsEnabled(true);

        if (player)
        {
            player.SetUnitMovementEnabled(false);
            player.ResetMove();

            var vc = player.GetVirtualCamera();
            if(vc)
            {
                vc.Priority = VirtualCameraInactivePriority;

                if (PanningCamera)
                {
                    PanningCamera.Priority = VirtualCameraActivePriority;
                    PanningCamera.ForceCameraPosition(vc.transform.position, vc.transform.rotation);
                }
            }
        }
    }

    public void OnQueryUnit(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            var hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(MousePosition), PlayerLayer);

            if (hit)
            {
                var unit = hit.gameObject.GetComponentInParent<PlayerController>();
                if (unit)
                {
                    SelectedUnit = units.IndexOf(unit);
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
        for (var i = 0; i < units.Count(); ++i)
        {
            var unit = units.ElementAt(i);
            var vc = unit.GetVirtualCamera();

            if (vc)
            {
                vc.Priority = VirtualCameraInactivePriority;
            }
        }
    }

    private void OnDrawGizmos()
    {
    }
}
