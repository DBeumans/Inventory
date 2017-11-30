using UnityEngine;
using System.Collections;

public enum ItemType
{
    weapons,
    food
}

public class Item {

    public Item(int itemId, ItemType itemType, string itemName)
    {
        this.id = itemId;
        this.type = itemType;
        this.name = itemName;
        this.sprite = Resources.Load<Sprite>("/Item/Prefabs/Images/" + this.name);
    }

    public Item()
    {
        this.id = -1;
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

    private Sprite sprite;
    public Sprite Sprite
    {
        get { return sprite; }
    }
}
