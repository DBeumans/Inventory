using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private Dictionary<ItemType, List<Item>> inventory = new Dictionary<ItemType, List<Item>>();

    private void Start()
    {
        Item it = new Item();
        for (int i = 0; i < 5; i++)
        {
            Item apple = new Item(0, ItemType.food, "Apple" + i);
            it = apple;
            addItem(apple);
        }

        Debug.Log(inventory[ItemType.food].Count);
        deleteItem(it);
        Debug.Log(inventory[ItemType.food].Count);

    }

    private void addItem(Item item)
    {
        // if the item type doens't exist in the inventory dictionary, we add it.
        if (!containsItemType(item.Type))
        {
            // adding the category.
            inventory.Add(item.Type, new List<Item>());
            // adding the item.
            inventory[item.Type].Add(item);
            return;
        }

        inventory[item.Type].Add(item);

    }

    private void deleteItem(Item item)
    {
        // check if the item type exist in the inventory, if not stop the function.
        if (!containsItemType(item.Type))
            return;

        // loop through the list.
        for (int i = 0; i < inventory[item.Type].Count; i++)
        {
            Item currentItem = inventory[item.Type][i];

            // check if the item ID and NAME are the same, if not stop.
            if (currentItem.ID != item.ID && currentItem.Name != item.Name)
                return;

            inventory[item.Type].Remove(item);
            Debug.Log("Deleted: " + "ID: " + item.ID + "Name: " + item.Name);
        }
    }

    private bool containsItemType(ItemType type)
    {
        return inventory.ContainsKey(type);
    }


}
