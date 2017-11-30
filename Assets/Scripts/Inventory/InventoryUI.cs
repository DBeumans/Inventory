using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour {

    private string buttonTag = "InventoryButtonSlot";

    [SerializeField]
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
        for (int i = 0; i < btns.Length ; i++)
        {
            inventoryButtons.Add(btns[i]);

        }
        inventoryButtons.Reverse();
    }
    
    public void addItem(Item item)
    {
        for (int i = 0; i < inventoryButtons.Count; i++)
        {
            GameObject currentButton = inventoryButtons[i];
            GameObject currentButtonChild = inventoryButtons[i].GetComponent<InventoryButton>().Child;
            InventoryButton inventoryButton = currentButtonChild.GetComponent<InventoryButton>();
            currentButton.name = item.Name;
            currentButtonChild.name = item.Name;
            inventoryButton.Sprite = item.Sprite;
            return;
        }
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
