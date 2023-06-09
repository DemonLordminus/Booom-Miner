//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Settings/InputAction/InputSettings.inputactions
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

namespace InputSettins
{
    public partial class @InputSettings: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputSettings()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSettings"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""d6c685d2-39a2-41a8-9a2d-806049e7f7cc"",
            ""actions"": [
                {
                    ""name"": ""MinerMove"",
                    ""type"": ""Value"",
                    ""id"": ""73d4986e-8de8-446d-b934-70421a8f5314"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""BattlerMove"",
                    ""type"": ""Value"",
                    ""id"": ""619b0009-9154-4bc7-98df-e7f4c1035fff"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6a677e4a-d7b4-40d1-a39c-d686a1979777"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseHook"",
                    ""type"": ""Button"",
                    ""id"": ""faf4d4cb-1453-4bfd-97db-88040b53c842"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseSteam"",
                    ""type"": ""Button"",
                    ""id"": ""06a31f7b-32aa-4e39-a1cd-6982dbd9891a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""8372ddad-aa62-43af-b0c5-c7e2bb71caa2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MinerMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a1314b1b-3ff4-476e-ae17-e837b77c9c53"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MinerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ebbeb17e-3668-4a8c-b241-6dfd8b9967a0"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MinerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e9f660c1-fa28-4fba-a43f-297f9b61d504"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0bcfc5fe-8bd1-4fc6-a478-826dbaaa535a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""UseHook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""377058b7-1b40-44a3-9d8c-d4b77c7bd847"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""UseSteam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""56994fae-5c27-4fd2-9dcc-d762e47989f5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BattlerMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""86f998e7-d8b4-4750-b8b2-23ef8aba12cc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""BattlerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d60f3df8-3cbc-4531-a348-cc412cc8d225"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""BattlerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4753c04b-a124-419c-a534-2dcce17d112d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""BattlerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4fef0c79-59f9-4112-96f3-ee890a9e34ad"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""BattlerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_MinerMove = m_Player.FindAction("MinerMove", throwIfNotFound: true);
            m_Player_BattlerMove = m_Player.FindAction("BattlerMove", throwIfNotFound: true);
            m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
            m_Player_UseHook = m_Player.FindAction("UseHook", throwIfNotFound: true);
            m_Player_UseSteam = m_Player.FindAction("UseSteam", throwIfNotFound: true);
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

        // Player
        private readonly InputActionMap m_Player;
        private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
        private readonly InputAction m_Player_MinerMove;
        private readonly InputAction m_Player_BattlerMove;
        private readonly InputAction m_Player_Jump;
        private readonly InputAction m_Player_UseHook;
        private readonly InputAction m_Player_UseSteam;
        public struct PlayerActions
        {
            private @InputSettings m_Wrapper;
            public PlayerActions(@InputSettings wrapper) { m_Wrapper = wrapper; }
            public InputAction @MinerMove => m_Wrapper.m_Player_MinerMove;
            public InputAction @BattlerMove => m_Wrapper.m_Player_BattlerMove;
            public InputAction @Jump => m_Wrapper.m_Player_Jump;
            public InputAction @UseHook => m_Wrapper.m_Player_UseHook;
            public InputAction @UseSteam => m_Wrapper.m_Player_UseSteam;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void AddCallbacks(IPlayerActions instance)
            {
                if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
                @MinerMove.started += instance.OnMinerMove;
                @MinerMove.performed += instance.OnMinerMove;
                @MinerMove.canceled += instance.OnMinerMove;
                @BattlerMove.started += instance.OnBattlerMove;
                @BattlerMove.performed += instance.OnBattlerMove;
                @BattlerMove.canceled += instance.OnBattlerMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @UseHook.started += instance.OnUseHook;
                @UseHook.performed += instance.OnUseHook;
                @UseHook.canceled += instance.OnUseHook;
                @UseSteam.started += instance.OnUseSteam;
                @UseSteam.performed += instance.OnUseSteam;
                @UseSteam.canceled += instance.OnUseSteam;
            }

            private void UnregisterCallbacks(IPlayerActions instance)
            {
                @MinerMove.started -= instance.OnMinerMove;
                @MinerMove.performed -= instance.OnMinerMove;
                @MinerMove.canceled -= instance.OnMinerMove;
                @BattlerMove.started -= instance.OnBattlerMove;
                @BattlerMove.performed -= instance.OnBattlerMove;
                @BattlerMove.canceled -= instance.OnBattlerMove;
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
                @UseHook.started -= instance.OnUseHook;
                @UseHook.performed -= instance.OnUseHook;
                @UseHook.canceled -= instance.OnUseHook;
                @UseSteam.started -= instance.OnUseSteam;
                @UseSteam.performed -= instance.OnUseSteam;
                @UseSteam.canceled -= instance.OnUseSteam;
            }

            public void RemoveCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IPlayerActions instance)
            {
                foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        public interface IPlayerActions
        {
            void OnMinerMove(InputAction.CallbackContext context);
            void OnBattlerMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnUseHook(InputAction.CallbackContext context);
            void OnUseSteam(InputAction.CallbackContext context);
        }
    }
}
