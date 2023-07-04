using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

//you need the low level InputSystem stuff
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

public class SnowCursor : MonoBehaviour
{
    public RectTransform cursorGraphic;
    public Vector2 currentPosition;

    MouseState currentMouseState;

    Mouse virtualMouse;

    public float speed = 1000;
    void Start()
    {
        //create a new fake mouse
        if (virtualMouse == null)
        {
            virtualMouse = (Mouse)InputSystem.AddDevice("VirtualMouse");
        }
        else if (!virtualMouse.added)
        {
            InputSystem.AddDevice(virtualMouse);
        }
        currentMouseState = new MouseState
        {
            position = new Vector2(0,0),
            delta = new Vector2(0, 0),
        };
        InputSystem.onAfterUpdate += UpdateMotion;
    }
    private void OnDisable()
    {
        if (virtualMouse != null && virtualMouse.added)
        {
            InputSystem.RemoveDevice(virtualMouse);
        }
        InputSystem.onAfterUpdate -= UpdateMotion;
    }
    void UpdateMotion()
    {
        //get the gamepad input
        var gamepad = Gamepad.current;
        var gamepadStickDelta = gamepad.rightStick.value * speed * Time.deltaTime;
        //get the currnet position of the fake mouse
        currentPosition = virtualMouse.position.ReadValue();
        var borderPad = 50;
        currentPosition = new Vector2(Mathf.Clamp(currentPosition.x, borderPad, Screen.width - borderPad), Mathf.Clamp(currentPosition.y, borderPad, Screen.height-borderPad));
        //use the gamepad input to change the position of the mosue. 



        currentMouseState.position = currentPosition + gamepadStickDelta;
        currentMouseState.delta = gamepadStickDelta;

        if (gamepad.aButton.isPressed)
        {
            currentMouseState.WithButton(MouseButton.Left, true);
        }
        else
        {
            currentMouseState.WithButton(MouseButton.Left, false);
        }

        InputState.Change(virtualMouse, currentMouseState);




        cursorGraphic.anchoredPosition = currentPosition;
    }
}