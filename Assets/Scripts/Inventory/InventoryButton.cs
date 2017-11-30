using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour {

    private Button btn;

    private GameObject child;
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
