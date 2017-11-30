using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour {

    private Button btn;

    private Image image;

    private Sprite sprite;
    public Sprite Sprite
    {
        get { return sprite; }
        set { sprite = value; }
    }

    private GameObject child;
    public GameObject Child
    {
        get { return child; }
    }
    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate () { onClick(); });

        image = GetComponent<Image>();
        image.sprite = sprite;

        child = this.gameObject.transform.GetChild(0).gameObject;
    }

    private void onClick()
    {

    }
}
