// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Inventory/InventoryInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InventoryInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InventoryInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InventoryInputActions"",
    ""maps"": [
        {
            ""name"": ""Inventory"",
            ""id"": ""5b2ff5ab-6247-47a4-b4b2-35423e1f14b5"",
            ""actions"": [
                {
                    ""name"": ""ScrollItems"",
                    ""type"": ""PassThrough"",
                    ""id"": ""aad498e1-4dad-44c5-ab14-96739bdcde68"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""MouseScroll"",
                    ""id"": ""a88346d7-c3cc-400c-9c3a-a2ed61302bc9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScrollItems"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""4138bada-23e4-4b36-900b-6c62a2a2e45c"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScrollItems"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""103c92e6-aab4-4912-9b0d-225fc8a007e6"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScrollItems"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Inventory
        m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
        m_Inventory_ScrollItems = m_Inventory.FindAction("ScrollItems", throwIfNotFound: true);
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

    // Inventory
    private readonly InputActionMap m_Inventory;
    private IInventoryActions m_InventoryActionsCallbackInterface;
    private readonly InputAction m_Inventory_ScrollItems;
    public struct InventoryActions
    {
        private @InventoryInputActions m_Wrapper;
        public InventoryActions(@InventoryInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ScrollItems => m_Wrapper.m_Inventory_ScrollItems;
        public InputActionMap Get() { return m_Wrapper.m_Inventory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
        public void SetCallbacks(IInventoryActions instance)
        {
            if (m_Wrapper.m_InventoryActionsCallbackInterface != null)
            {
                @ScrollItems.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnScrollItems;
                @ScrollItems.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnScrollItems;
                @ScrollItems.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnScrollItems;
            }
            m_Wrapper.m_InventoryActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ScrollItems.started += instance.OnScrollItems;
                @ScrollItems.performed += instance.OnScrollItems;
                @ScrollItems.canceled += instance.OnScrollItems;
            }
        }
    }
    public InventoryActions @Inventory => new InventoryActions(this);
    public interface IInventoryActions
    {
        void OnScrollItems(InputAction.CallbackContext context);
    }
}
