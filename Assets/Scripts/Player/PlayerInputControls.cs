// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerInputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""663df77c-1dae-4f58-8786-8cd3e6ac741c"",
            ""actions"": [
                {
                    ""name"": ""WalkHorizontal"",
                    ""type"": ""Value"",
                    ""id"": ""6260a8cf-b7e7-4dc8-9e68-0b46fa9eb4bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WalkVertical"",
                    ""type"": ""Value"",
                    ""id"": ""f2cd872f-d56d-462b-aa2e-9f0d365a5ed2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""7cc1ac58-f653-40fe-b870-5cfa1954ba8e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dialogue"",
                    ""type"": ""Button"",
                    ""id"": ""40125be1-af8c-40d5-b322-35edc6ce78b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""4bf2dced-5671-43ca-a276-32662ed984cf"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e1ba0875-425e-4747-813c-60bfb68b57f6"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""87a19464-cfa9-4026-a66d-a4ca440b24aa"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LetterKeys"",
                    ""id"": ""b1d1e96d-ca69-494f-b33f-491c4432f8e1"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""0db83cdb-e699-421d-ba04-674b32f1aac0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""2ab05a87-225c-42b6-b242-330d9c44b059"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""272989b4-bd54-4401-bc18-8878a8be4899"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""44a31ebb-a5ff-4a26-b60c-5eb4564101e7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""54995419-2a46-475e-a3b2-9d88c0b00363"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LetterKeys"",
                    ""id"": ""68af2d75-fbf7-4963-b12b-7f794ba0ab70"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""565e5afe-9a14-456d-9186-bdda15965ebc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b477f184-1ac4-4eb2-b462-03ecd46edea5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cc8e359b-b29f-483e-ae85-4b0cd463907e"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28843a6f-49f1-45c1-9624-863b7cb92529"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dialogue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_WalkHorizontal = m_Player.FindAction("WalkHorizontal", throwIfNotFound: true);
        m_Player_WalkVertical = m_Player.FindAction("WalkVertical", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Dialogue = m_Player.FindAction("Dialogue", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_WalkHorizontal;
    private readonly InputAction m_Player_WalkVertical;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Dialogue;
    public struct PlayerActions
    {
        private @PlayerInputControls m_Wrapper;
        public PlayerActions(@PlayerInputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @WalkHorizontal => m_Wrapper.m_Player_WalkHorizontal;
        public InputAction @WalkVertical => m_Wrapper.m_Player_WalkVertical;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Dialogue => m_Wrapper.m_Player_Dialogue;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @WalkHorizontal.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalkHorizontal;
                @WalkHorizontal.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalkHorizontal;
                @WalkHorizontal.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalkHorizontal;
                @WalkVertical.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalkVertical;
                @WalkVertical.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalkVertical;
                @WalkVertical.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalkVertical;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Dialogue.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDialogue;
                @Dialogue.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDialogue;
                @Dialogue.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDialogue;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @WalkHorizontal.started += instance.OnWalkHorizontal;
                @WalkHorizontal.performed += instance.OnWalkHorizontal;
                @WalkHorizontal.canceled += instance.OnWalkHorizontal;
                @WalkVertical.started += instance.OnWalkVertical;
                @WalkVertical.performed += instance.OnWalkVertical;
                @WalkVertical.canceled += instance.OnWalkVertical;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Dialogue.started += instance.OnDialogue;
                @Dialogue.performed += instance.OnDialogue;
                @Dialogue.canceled += instance.OnDialogue;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnWalkHorizontal(InputAction.CallbackContext context);
        void OnWalkVertical(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnDialogue(InputAction.CallbackContext context);
    }
}
