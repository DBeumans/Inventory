using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

    /// <summary>
    /// Dictionary to store all the existing items.
    /// </summary>
    private List<GameObject> itemDatabase = new List<GameObject>();

    /// <summary>
    /// getter so other scripts can read whats in the item database list.
    /// </summary>
    public List<GameObject> ItemDataBaseList
    {
        get { return itemDatabase; }
    }

    /// <summary>
    /// Path to the folder where the item prefabs are located.
    /// </summary>
    private string itemFolderPath = "Item/Prefabs/";

    private void Awake()
    {
        getItemPrefabs();
    }

    /// <summary>
    /// Get prefabs from the Resource/Item folder.
    /// </summary>
    private void getItemPrefabs()
    {
        //Store all the prefabs in object array
        object[] items = Resources.LoadAll(itemFolderPath);

        //loop through the items array.
        for (int i = 0; i < items.Length; i++)
        {
            //create a local variable that holds the current item in the loop.
            GameObject item = (GameObject)items[i];

            //add the current item to the item database list.
            itemDatabase.Add(item);
        }
    }
}
