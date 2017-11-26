using UnityEngine;
using System.Collections;

public enum ItemType
{
    ZERO,
    weapons,
    food
}

public class Item {

    public Item(int itemId, ItemType itemType, string itemName)
    {
        this.id = itemId;
        this.type = itemType;
        this.name = itemName;
    }

    public Item()
    {
        this.id = -1;
        this.type = ItemType.ZERO;
        this.name = "Null_Item";
    }

    private int id;
    public int ID
    {
        get { return id; }
    }

    private ItemType type;
    public ItemType Type
    {
        get { return type; }
    }

    private string name;
    public string Name
    {
        get { return name; }
    }
}
