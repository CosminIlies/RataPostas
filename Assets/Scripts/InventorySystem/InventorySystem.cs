using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    #region Singleton
    public static InventorySystem Instance;
    private void Awake()
    {
        Instance = this;    
    }
    #endregion


    [SerializeField]
    private Transform itemSlot;

    [SerializeField]
    private Transform inventoryParen;

    [SerializeField]
    private List<Item> inventory = new List<Item>();

    public Item TestItem;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            AddItem(TestItem);
        }
    }


    private void updateUI()
    {
        for (int i = 0; i < inventoryParen.childCount; i++)
        {
            Destroy(inventoryParen.GetChild(i).gameObject);
        }

        foreach(Item item in inventory)
        {
            Instantiate(itemSlot, inventoryParen).GetComponent<ItemSlotGui>().SetItem(item);
        }

    }
    public void AddItem(Item item)
    {
        inventory.Add(item);
        updateUI();
    }

    public void RemoveItem(Item item)
    {
        inventory.Remove(item);
        updateUI();
    }

    public bool HaveItem(Item item)
    {
        return inventory.Contains(item);   
    }
    public List<Item> GetAllItems()
    {
        return inventory;
    }
}
