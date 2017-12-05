using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour {

    private string buttonParentTag = "InventoryButtonSlotPanel";

    [SerializeField]
    private List<GameObject> inventoryButtons = new List<GameObject>();

    private Inventory inventory;

    private void Awake()
    {
       //inventory = GetComponent<Inventory>();
        getInventoryUIButtons();
    }

    private void getInventoryUIButtons()
    {
        GameObject parentObject = GameObject.FindGameObjectWithTag(buttonParentTag);

        foreach (Transform transform in parentObject.transform)
        {
            inventoryButtons.Add(transform.gameObject);
        }
    }
    
    public void addItem(Item item)
    {
        for (int i = 0; i < inventoryButtons.Count; i++)
        {
            GameObject currentButton = inventoryButtons[i];
            GameObject childButton = inventoryButtons[i].transform.GetChild(0).gameObject;
            InventoryButton inventoryButton = currentButton.GetComponent<InventoryButton>();

            if (inventoryButton.HasItem)
                continue;

            currentButton.name = item.Name;
            childButton.name = item.Name;
            inventoryButton.HasItem = true;
            inventoryButton.Item = item;

            childButton.GetComponent<Image>().sprite = item.Sprite;
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
