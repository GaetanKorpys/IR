using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<ItemData> content = new List<ItemData>();

    [SerializeField]
    private GameObject inventoryPanel;

    [SerializeField]
    private Transform inventorySlotParent;

    const int InventorySize = 6;

    private void Start()
    {
        RefreshContent();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }

    public void AddItem(ItemData item)
    {
        content.Add(item);
        RefreshContent();
    }

    public void CloseInventory()
    { 
        inventoryPanel.SetActive(false); 
    }

    private void RefreshContent()
    {
        for (int i = 0; i < content.Count; i++)
        {
            Slot currentSlot = inventorySlotParent.GetChild(i).GetComponent<Slot>();
            currentSlot.item = content[i];
            currentSlot.itemVisual.sprite = content[i].visual;
        }
    }

    public bool IsFull()
    {
        return InventorySize == content.Count;
    }
    
}
