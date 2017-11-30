using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour {

    private string buttonTag = "InventoryButtonSlot";

    private List<GameObject> inventoryButtons = new List<GameObject>();

    private Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
        getInventoryUIButtons();
    }

    private void getInventoryUIButtons()
    {
        GameObject[] btns = GameObject.FindGameObjectsWithTag(buttonTag);
        for (int i = 0; i < btns.Length; i++)
        {
            inventoryButtons.Add(btns[i]);
        }
    }
    
    public void addItem(Item item)
    {

    }

    private void updateInventoryUI()
    {
        for (int i = 0; i < inventoryButtons.Count; i++)
        {

        }
    }

    private void showItems(List<Item> items)
    {

    }
}
