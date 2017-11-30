using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour {

    private bool hasItem;
    public bool HasItem
    {
        get { return hasItem; }
        set { hasItem = value; }
    }

    private Button btn;

    private GameObject child;
    public GameObject Child
    {
        get { return child; }
    }
    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate () { onClick(); });

        child = this.gameObject.transform.GetChild(0).gameObject;
    }

    private void onClick()
    {

    }
}
