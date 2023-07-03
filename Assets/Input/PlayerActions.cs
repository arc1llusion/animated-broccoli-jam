//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/Input/PlayerActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""Unit"",
            ""id"": ""faae3522-ca6f-44d8-9b0b-b10104cb1006"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""5d90e8ff-3b07-473c-809f-b598f03fa5f1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""98588ae8-a536-45bc-9056-115a5300bb69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GoBack"",
                    ""type"": ""Button"",
                    ""id"": ""2e70b661-e178-4625-be7c-59ea71aaa6ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""40c7e57a-b9b2-4173-a629-636b1938d331"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8cfc7f24-42f7-49c4-ab81-a104bea7ceab"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""35b484f0-bd0c-4161-b123-44f5216bb50e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""c276ba12-be40-4c06-a5b1-352607fadb2a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""c4fea7db-ce90-43ec-9533-0813a44130dd"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""6d2d7640-fd37-4be8-9c93-5339441500cb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""38e94abb-ad2a-42f1-b0d7-99459db81725"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""3485569b-81f6-4558-bee4-1f9109d88ced"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""488763e1-6ae2-4ce6-a40e-110a0391202b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""b4c80dec-2b01-462d-8779-722e1989b940"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""9499f433-f461-43e8-84f3-ae724d652a2f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6b16d0d1-d2d1-4aaf-a86d-2f6d5768e0f6"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c14f2809-9c31-4c7f-b072-62d3511ead36"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79e62b90-03f2-4baa-9fd6-7838c7727487"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""GoBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34b96cee-4ce2-4ed6-ab10-db702cf01f5f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""GoBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""912dd04b-a03b-4f1b-99a3-b8e6259c522d"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""541de1eb-517a-430d-9660-3fe1e2e46621"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Selection"",
            ""id"": ""1f94d32a-b7a6-4009-8900-7de8558dc5bf"",
            ""actions"": [
                {
                    ""name"": ""MoveCamera"",
                    ""type"": ""Value"",
                    ""id"": ""c1c08cf7-0cb5-4027-9913-d0fad481c17b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""QuickSelect"",
                    ""type"": ""Value"",
                    ""id"": ""275b797f-e166-4a6a-a5a7-9f8517934ef0"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SelectUnit"",
                    ""type"": ""Button"",
                    ""id"": ""0ade657b-8ca4-4376-aff5-8db07954beaf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""QueryUnit"",
                    ""type"": ""Button"",
                    ""id"": ""cd37f5be-7b3d-4138-9dd5-a7bb22d1ae75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CursorUpdate"",
                    ""type"": ""Value"",
                    ""id"": ""736f0790-6bf7-474d-828c-19fdd9dd8f07"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9b95a9c7-f10c-4e64-956b-a8cc5f6e808c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""9a4c5096-7ac9-4389-8330-c96448354854"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""eca5c66a-2429-4032-8064-ee91ce656064"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""b32ae79f-1ae3-4a96-a17e-b22bf0435c22"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""90324a67-cf17-4df2-9b0d-11488597189c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""c9e686b7-24f5-4b39-9fe0-aaddd82d8151"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""5144246a-5d1a-4340-ba4e-92f2f0348c92"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""6e659f27-43c7-435d-b957-2bc91fce615b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""adeb776b-d5c2-483e-9c81-3cef8e8e74ac"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""0b2bb3a4-d5fc-4dc9-ad36-20516466d63d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftRIght"",
                    ""id"": ""5bc57f86-e966-4f68-a7d7-8eca776cf270"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickSelect"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""85303b50-27a6-4f91-8218-c0addcf8eb24"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""QuickSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6ced58c4-a170-4da4-a98b-e686f39544d2"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""QuickSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""DPad"",
                    ""id"": ""6f81f36e-4fdb-4da9-b9d5-4cc05b37d927"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickSelect"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a8b281aa-fd53-4cdf-8682-ccabe76db7bd"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""QuickSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""dac41c33-421f-4033-9340-f31741c52aed"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""QuickSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d1276ac7-1884-4b74-9eb1-75a35156b6e2"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""SelectUnit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c6b25c0-571b-4242-a7eb-407bda6adc34"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""QueryUnit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""420f5235-4b2b-4596-8f6c-389d59624252"",
                    ""path"": ""<VirtualMouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""QueryUnit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fdb5071-251b-4efa-ab56-fcbae7477dc7"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""CursorUpdate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28bbffc7-5b58-4280-9d56-7efd98b699f3"",
                    ""path"": ""<VirtualMouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CursorUpdate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<VirtualMouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Unit
        m_Unit = asset.FindActionMap("Unit", throwIfNotFound: true);
        m_Unit_Move = m_Unit.FindAction("Move", throwIfNotFound: true);
        m_Unit_Sprint = m_Unit.FindAction("Sprint", throwIfNotFound: true);
        m_Unit_GoBack = m_Unit.FindAction("GoBack", throwIfNotFound: true);
        m_Unit_Confirm = m_Unit.FindAction("Confirm", throwIfNotFound: true);
        // Selection
        m_Selection = asset.FindActionMap("Selection", throwIfNotFound: true);
        m_Selection_MoveCamera = m_Selection.FindAction("MoveCamera", throwIfNotFound: true);
        m_Selection_QuickSelect = m_Selection.FindAction("QuickSelect", throwIfNotFound: true);
        m_Selection_SelectUnit = m_Selection.FindAction("SelectUnit", throwIfNotFound: true);
        m_Selection_QueryUnit = m_Selection.FindAction("QueryUnit", throwIfNotFound: true);
        m_Selection_CursorUpdate = m_Selection.FindAction("CursorUpdate", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Unit
    private readonly InputActionMap m_Unit;
    private List<IUnitActions> m_UnitActionsCallbackInterfaces = new List<IUnitActions>();
    private readonly InputAction m_Unit_Move;
    private readonly InputAction m_Unit_Sprint;
    private readonly InputAction m_Unit_GoBack;
    private readonly InputAction m_Unit_Confirm;
    public struct UnitActions
    {
        private @PlayerActions m_Wrapper;
        public UnitActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Unit_Move;
        public InputAction @Sprint => m_Wrapper.m_Unit_Sprint;
        public InputAction @GoBack => m_Wrapper.m_Unit_GoBack;
        public InputAction @Confirm => m_Wrapper.m_Unit_Confirm;
        public InputActionMap Get() { return m_Wrapper.m_Unit; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UnitActions set) { return set.Get(); }
        public void AddCallbacks(IUnitActions instance)
        {
            if (instance == null || m_Wrapper.m_UnitActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UnitActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Sprint.started += instance.OnSprint;
            @Sprint.performed += instance.OnSprint;
            @Sprint.canceled += instance.OnSprint;
            @GoBack.started += instance.OnGoBack;
            @GoBack.performed += instance.OnGoBack;
            @GoBack.canceled += instance.OnGoBack;
            @Confirm.started += instance.OnConfirm;
            @Confirm.performed += instance.OnConfirm;
            @Confirm.canceled += instance.OnConfirm;
        }

        private void UnregisterCallbacks(IUnitActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Sprint.started -= instance.OnSprint;
            @Sprint.performed -= instance.OnSprint;
            @Sprint.canceled -= instance.OnSprint;
            @GoBack.started -= instance.OnGoBack;
            @GoBack.performed -= instance.OnGoBack;
            @GoBack.canceled -= instance.OnGoBack;
            @Confirm.started -= instance.OnConfirm;
            @Confirm.performed -= instance.OnConfirm;
            @Confirm.canceled -= instance.OnConfirm;
        }

        public void RemoveCallbacks(IUnitActions instance)
        {
            if (m_Wrapper.m_UnitActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUnitActions instance)
        {
            foreach (var item in m_Wrapper.m_UnitActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UnitActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UnitActions @Unit => new UnitActions(this);

    // Selection
    private readonly InputActionMap m_Selection;
    private List<ISelectionActions> m_SelectionActionsCallbackInterfaces = new List<ISelectionActions>();
    private readonly InputAction m_Selection_MoveCamera;
    private readonly InputAction m_Selection_QuickSelect;
    private readonly InputAction m_Selection_SelectUnit;
    private readonly InputAction m_Selection_QueryUnit;
    private readonly InputAction m_Selection_CursorUpdate;
    public struct SelectionActions
    {
        private @PlayerActions m_Wrapper;
        public SelectionActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveCamera => m_Wrapper.m_Selection_MoveCamera;
        public InputAction @QuickSelect => m_Wrapper.m_Selection_QuickSelect;
        public InputAction @SelectUnit => m_Wrapper.m_Selection_SelectUnit;
        public InputAction @QueryUnit => m_Wrapper.m_Selection_QueryUnit;
        public InputAction @CursorUpdate => m_Wrapper.m_Selection_CursorUpdate;
        public InputActionMap Get() { return m_Wrapper.m_Selection; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SelectionActions set) { return set.Get(); }
        public void AddCallbacks(ISelectionActions instance)
        {
            if (instance == null || m_Wrapper.m_SelectionActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SelectionActionsCallbackInterfaces.Add(instance);
            @MoveCamera.started += instance.OnMoveCamera;
            @MoveCamera.performed += instance.OnMoveCamera;
            @MoveCamera.canceled += instance.OnMoveCamera;
            @QuickSelect.started += instance.OnQuickSelect;
            @QuickSelect.performed += instance.OnQuickSelect;
            @QuickSelect.canceled += instance.OnQuickSelect;
            @SelectUnit.started += instance.OnSelectUnit;
            @SelectUnit.performed += instance.OnSelectUnit;
            @SelectUnit.canceled += instance.OnSelectUnit;
            @QueryUnit.started += instance.OnQueryUnit;
            @QueryUnit.performed += instance.OnQueryUnit;
            @QueryUnit.canceled += instance.OnQueryUnit;
            @CursorUpdate.started += instance.OnCursorUpdate;
            @CursorUpdate.performed += instance.OnCursorUpdate;
            @CursorUpdate.canceled += instance.OnCursorUpdate;
        }

        private void UnregisterCallbacks(ISelectionActions instance)
        {
            @MoveCamera.started -= instance.OnMoveCamera;
            @MoveCamera.performed -= instance.OnMoveCamera;
            @MoveCamera.canceled -= instance.OnMoveCamera;
            @QuickSelect.started -= instance.OnQuickSelect;
            @QuickSelect.performed -= instance.OnQuickSelect;
            @QuickSelect.canceled -= instance.OnQuickSelect;
            @SelectUnit.started -= instance.OnSelectUnit;
            @SelectUnit.performed -= instance.OnSelectUnit;
            @SelectUnit.canceled -= instance.OnSelectUnit;
            @QueryUnit.started -= instance.OnQueryUnit;
            @QueryUnit.performed -= instance.OnQueryUnit;
            @QueryUnit.canceled -= instance.OnQueryUnit;
            @CursorUpdate.started -= instance.OnCursorUpdate;
            @CursorUpdate.performed -= instance.OnCursorUpdate;
            @CursorUpdate.canceled -= instance.OnCursorUpdate;
        }

        public void RemoveCallbacks(ISelectionActions instance)
        {
            if (m_Wrapper.m_SelectionActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISelectionActions instance)
        {
            foreach (var item in m_Wrapper.m_SelectionActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SelectionActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SelectionActions @Selection => new SelectionActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    public interface IUnitActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnGoBack(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
    }
    public interface ISelectionActions
    {
        void OnMoveCamera(InputAction.CallbackContext context);
        void OnQuickSelect(InputAction.CallbackContext context);
        void OnSelectUnit(InputAction.CallbackContext context);
        void OnQueryUnit(InputAction.CallbackContext context);
        void OnCursorUpdate(InputAction.CallbackContext context);
    }
}
