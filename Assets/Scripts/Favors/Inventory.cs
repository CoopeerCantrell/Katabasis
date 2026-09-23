using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using TMPro;



public class Inventory : MonoBehaviour
{
    public InputSystem_Actions inputActions;
    [SerializeField] private InputAction interactAction;
    [SerializeField] private InputAction openAction;
    [SerializeField] private InputAction scrollAction;
    [SerializeField] private InputAction dropAction;
    [SerializeField] private InputAction useAction;
    [SerializeField] private InputAction throwAction;

    public static Inventory instance;

    public GameObject hotbarObj;


 
    private Material originalMaterial;
  
    private int equippedHotbarIndex = 0;
    public float equippedOpacity = 0.9f;
    public float normalOpacity = 0.58f;
    public Transform camTransform;
    public Transform hand;
    private GameObject currentHandItem;



    private List<Slot> hotbarSlots = new List<Slot>();
    private List<Slot> allSlots = new List<Slot>();

    private void Awake()
    {
        instance = this;
        inputActions = new InputSystem_Actions();



        hotbarSlots.AddRange(hotbarObj.GetComponentsInChildren<Slot>());


        allSlots.AddRange(hotbarSlots);
    }
    private void OnEnable()
    {
        inputActions.Enable();
        Debug.Log("something happens");



        useAction.Enable();
        useAction.performed += OnUse;

        throwAction.Enable();
        throwAction.performed += OnThrow;
        Debug.Log("open action enabled");
    }

    private void OnDisable()
    {
        inputActions.Disable();


        useAction.performed -= OnUse;
        useAction.Disable();

        throwAction.performed -= OnThrow;
        throwAction.Disable();
        Debug.Log("open action disabled");
    }
    void Update()
    {

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            SelectHotbarSlot(0);

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            SelectHotbarSlot(1);

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            SelectHotbarSlot(2);

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
            SelectHotbarSlot(3);

        if (Keyboard.current.digit5Key.wasPressedThisFrame)
            SelectHotbarSlot(4);

        if (Keyboard.current.digit6Key.wasPressedThisFrame)
            SelectHotbarSlot(5);

        UpdateHotbarOpacity();
    }


    public void OnUse(InputAction.CallbackContext ctx)
    {
        Debug.Log("use");
        if (currentHandItem == null)
            return;

        currentHandItem.SendMessage("Use", SendMessageOptions.DontRequireReceiver);
    }

    private void OnThrow(InputAction.CallbackContext ctx)
    {
        if (currentHandItem == null)
            return;

        currentHandItem.SendMessage("Throw", SendMessageOptions.DontRequireReceiver);
    }
    public void AddItem(ItemSO itemToAdd, int amount)
    {
        Debug.Log(" item:" + itemToAdd +"amount "+  amount);
        int remanining = amount;
        foreach (Slot slot in allSlots)
        {
            if (slot.HasItem() && slot.GetItem() == itemToAdd)
            {
                int currentAmount = slot.GetAmount();
                int maxStack = itemToAdd.maxStackSize;

                if (currentAmount < maxStack)
                {
                    int spaceLeft = maxStack - currentAmount;
                    int amountToAdd = Mathf.Min(spaceLeft, remanining);

                    slot.Setitem(itemToAdd, currentAmount + amountToAdd);
                    remanining -= amountToAdd;

                    if (remanining <= 0)
                    {
                        EquipHandItem();
                        return;
                    }
                }
            }
        }

        foreach (Slot slot in allSlots)
        {
            if (!slot.HasItem())
            {
                int amountToPlace = Mathf.Min(itemToAdd.maxStackSize, remanining);
                slot.Setitem(itemToAdd, amountToPlace);
                remanining -= amountToPlace;

                if (remanining <= 0)
                {
                    return;
                }
            }
        }

        if (remanining > 0)
        {
            Debug.Log("Inventory is full, could not add" + remanining + "of" + itemToAdd.itemName);
        }
    }

   

    private void UpdateHotbarOpacity()
    {
        for (int i = 0; i < hotbarSlots.Count; i++)
        {
            Image icon = hotbarSlots[i].GetComponent<Image>();
            if (icon != null)
            {
                icon.color = (i == equippedHotbarIndex) ? new Color(1, 1, 1, equippedOpacity) : new Color(1, 1, 1, normalOpacity);
            }
        }
    }

    private void SelectHotbarSlot(int index)
    {
        if (index < 0 || index >= hotbarSlots.Count)
            return;

        equippedHotbarIndex = index;
        UpdateHotbarOpacity();
        EquipHandItem();

        Slot slot = hotbarSlots[equippedHotbarIndex];

        if (slot.HasItem())
        {
            Debug.Log("Equipped " + slot.GetItem().itemName);
        }
        else
        {
            Debug.Log("Hands Empty");
        }
    }
    public Slot GetEquippedSlot()
    {
        return hotbarSlots[equippedHotbarIndex];
    }

    public ItemSO GetEquippedItem()
    {
        Slot slot = GetEquippedSlot();

        if (!slot.HasItem())
            return null;

        return slot.GetItem();
    }

    public void EquipHandItem()
    {
        Debug.Log("should Equip hand item");
        if (currentHandItem != null)
        {

            currentHandItem.SendMessage("UnEquip", SendMessageOptions.DontRequireReceiver);
            Destroy(currentHandItem);
        }

        Slot equippedSlot = GetEquippedSlot();
        if (!equippedSlot.HasItem()) return;

        ItemSO item = GetEquippedItem();
        if (item.handItemPrefab == null) return;

        currentHandItem = Instantiate(item.handItemPrefab, hand);
        currentHandItem.transform.localPosition = Vector3.zero;
        currentHandItem.transform.localRotation = Quaternion.identity;
        

        
    }
    private Slot GetHoveredSlot()
    {
        foreach (Slot s in allSlots)
        {
            if (s.hovering)
                return s;
        }

        return null;
    }


    public void ConsumeEquippedItem(int amount = 1)
    {
        Slot equippedSlot = GetEquippedSlot();

        if (!equippedSlot.HasItem()) return;

        int newAmount = equippedSlot.GetAmount() - amount;

        if (newAmount <= 0)
        {
            equippedSlot.ClearSlot();
        }
        else
        {
            equippedSlot.Setitem(equippedSlot.GetItem(), newAmount);
        }
    }
}

