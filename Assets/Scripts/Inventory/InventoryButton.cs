using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

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

    private Item item;
    public Item Item
    {
        get { return item; }
        set
        {
            if(value != null)
                item = value;
        }
    }
    private ButtonState buttonState;

    private InventoryToolTip toolTip;

    private void Start()
    {
        //Get the ButtonState script and save it into buttonState variable.
        //Must be locally because we want the buttonState of our own button.
        buttonState = GetComponent<ButtonState>();

        toolTip = GameObject.FindGameObjectWithTag("ToolTip").GetComponent<InventoryToolTip>();

        btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate () { onClick(); });

        child = this.gameObject.transform.GetChild(0).gameObject;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item == null)
            return;
        toolTip.Show(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toolTip.Hide();
        return;
    }

    private void onClick()
    {
        Debug.Log(this.hasItem + "\n" + child.name);
        /*
            - check if hold item
                - grab item.
            
            - show item stats on hover.

            als ik over de item gaat, laat dan de item stats zien.
            als ik de item weg sleep ( met left klik ), gaat de item naar mijn muis position, als ik de muis button
            los laat dan gaat de item naar de plek waar mijn muis staat, is het niet een vakje in mijn 
            inventory dan gaat het naar zijn oude positie, is de inventory vakje bezet swap item.
        */
    }
}
