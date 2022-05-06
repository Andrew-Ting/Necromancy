// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/TextBoxes/TextBoxInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TextBoxInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TextBoxInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TextBoxInputActions"",
    ""maps"": [
        {
            ""name"": ""TextBox"",
            ""id"": ""6557867a-270a-4361-8b5c-53b6901806d7"",
            ""actions"": [
                {
                    ""name"": ""DialogueProgression"",
                    ""type"": ""Button"",
                    ""id"": ""b4171ad6-e559-40bc-a95b-7db648bdc64a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0e0416f1-3a32-4499-8d21-de5da08079e4"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DialogueProgression"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b98028a3-69a8-47ea-9afa-453e55334c7d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DialogueProgression"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TextBox
        m_TextBox = asset.FindActionMap("TextBox", throwIfNotFound: true);
        m_TextBox_DialogueProgression = m_TextBox.FindAction("DialogueProgression", throwIfNotFound: true);
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

    // TextBox
    private readonly InputActionMap m_TextBox;
    private ITextBoxActions m_TextBoxActionsCallbackInterface;
    private readonly InputAction m_TextBox_DialogueProgression;
    public struct TextBoxActions
    {
        private @TextBoxInputActions m_Wrapper;
        public TextBoxActions(@TextBoxInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @DialogueProgression => m_Wrapper.m_TextBox_DialogueProgression;
        public InputActionMap Get() { return m_Wrapper.m_TextBox; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TextBoxActions set) { return set.Get(); }
        public void SetCallbacks(ITextBoxActions instance)
        {
            if (m_Wrapper.m_TextBoxActionsCallbackInterface != null)
            {
                @DialogueProgression.started -= m_Wrapper.m_TextBoxActionsCallbackInterface.OnDialogueProgression;
                @DialogueProgression.performed -= m_Wrapper.m_TextBoxActionsCallbackInterface.OnDialogueProgression;
                @DialogueProgression.canceled -= m_Wrapper.m_TextBoxActionsCallbackInterface.OnDialogueProgression;
            }
            m_Wrapper.m_TextBoxActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DialogueProgression.started += instance.OnDialogueProgression;
                @DialogueProgression.performed += instance.OnDialogueProgression;
                @DialogueProgression.canceled += instance.OnDialogueProgression;
            }
        }
    }
    public TextBoxActions @TextBox => new TextBoxActions(this);
    public interface ITextBoxActions
    {
        void OnDialogueProgression(InputAction.CallbackContext context);
    }
}
