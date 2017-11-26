using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    /// <summary>
    /// The inventory, which is a dictionary so you can have items separated by their types.
    /// </summary>
    private Dictionary<ItemType, Dictionary<int, List<Item>>> inventory = new Dictionary<ItemType, Dictionary<int, List<Item>>>();
    /*
     * <<REMINDER>>
     * Inventory output :
     * --ItemType--ItemID--List with items
     * example:
     * Food // category
     * ----"0" //id
     * ----------Apple, Apple //items
     * ----"1" //id
     * ----------Cookie, Cookie //items
     * 
     * It stores items with same id in an list.
     * */

    private void Awake()
    {
        // store all the enum types in a string array.
        string[] itemTypes = System.Enum.GetNames(typeof(ItemType));

        // loop through the itemTypes string array.
        for (int i = 0; i < itemTypes.Length; i++)
        {
            // add every enum type to the inventory.
            AddItemTypeToInventory(itemTypes[i]);
        }
    }

    private void Start()
     {
         Item it = new Item();
         for (int i = 0; i< 5; i++)
         {
             Item apple = new Item(0, ItemType.food, "Apple" + i);
             it = apple;
             addItem(apple);
         }
        Debug.Log("FoodType: " +inventory[ItemType.food].Count);
        Debug.Log(inventory[ItemType.food][0].Count);
 
     }

    /// <summary>
    /// Add a item type to the inventory with string.
    /// This function also convert the string to enum type.
    /// </summary>
    /// <param name="type"></param>
    private void AddItemTypeToInventory(string type)
    {
        // convert the string into enum type.
        ItemType itemType = (ItemType) System.Enum.Parse(typeof(ItemType), type);

        // if the inventory already contains the type, stop.
        if (containsItemType(itemType))
            return;

        // add the type to the inventory.
        inventory.Add(itemType, new Dictionary<int, List<Item>>());
    }

    /// <summary>
    /// Adds the item to the inventory and also in the correct category.
    /// </summary>
    /// <param name="item"></param>
    private void addItem(Item item)
    {        
        //if its the first item from the itemtype list, add a new list init.
        if(!containsItemList(item.Type, item.ID))
            inventory[item.Type].Add(item.ID, new List<Item>());

        // add the item to the inventory.
        inventory[item.Type][item.ID].Add(item);
    }

    /// <summary>
    /// Deletes the item from the inventory.
    /// </summary>
    /// <param name="item"></param>
    private void deleteItem(Item item)
    {
        // loop through the list.
        for (int i = 0; i < inventory[item.Type].Count; i++)
        {
            //set the current " i " value to a item variable.
            Item currentItem = inventory[item.Type][item.ID][i];

            // check if the item ID and NAME are the same, if not stop.
            if (currentItem.ID != item.ID && currentItem.Name != item.Name)
                return;

            
            //remove the item from the inventory.
            inventory[item.Type][item.ID].Remove(item);

            //if its the last item from the inventory, remove the corresponding list init.
            if (inventory[item.Type][item.ID].Count <= 0)
            {
                inventory[item.Type].Remove(item.ID);
            }
        }
    }

    /// <summary>
    /// Checks if the inventory contains the itemType
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private bool containsItemType(ItemType type)
    {
        //checks if the inventory contains the type, returns true / false boolean.
        return inventory.ContainsKey(type);
    }

    /// <summary>
    /// Checks if the item category contains a list with the given item name.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    private bool containsItemList(ItemType type, int id)
    {
        //checks if the inventory [type] contains the items list.
        return inventory[type].ContainsKey(id);
    }

    /// <summary>
    /// Checks if the inventory contains the item.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private bool containsItem(Item item)
    {
        // loop through the list.
        for (int i = 0; i < inventory[item.Type].Count; i++)
        {
            //set the current " i " value to a item variable.
            Item currentItem = inventory[item.Type][item.ID][i];
            
            // check if the item is in the list.
            if (item.Name == currentItem.Name && item.ID == currentItem.ID)
                return true;    
        }
        // Item is not in the inventory.
        return false;
    }


}
