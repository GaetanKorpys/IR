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

    const int InventorySize = 12;

    private bool isOpen = false;

    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        RefreshContent();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOpen)
                CloseInventory();
            else
                OpenInventory();
        }   
    }

    public void AddItem(ItemData item)
    {
        content.Add(item);
        RefreshContent();
    }

    private void OpenInventory()
    {
        inventoryPanel.SetActive(true);
        isOpen = true;
    }

    public void CloseInventory()
    { 
        inventoryPanel.SetActive(false);
        ToolTipSystem.instance.Hide();
        isOpen = false;
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

    public bool isGameVictory()
    {
        bool dent = false;
        bool liquide = false;

        foreach(ItemData item in content)
            if(item.name == "Dent")
                dent = true;
            else if(item.name == "Bouteille d'eau")
                liquide = true;
            else if(item.name == "Brique de lait")
                liquide = true;
            else if (item.name == "Tetrapack de lait")
                liquide = true;
            else if (item.name == "Bouteille de lait en verre")
                liquide = true;

        if(dent && liquide)
            return true;
        return false;
    }
    
}
