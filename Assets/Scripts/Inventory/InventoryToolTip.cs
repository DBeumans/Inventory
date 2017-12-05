using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryToolTip : MonoBehaviour {

    private Item item;

    private string itemName;

    private Image image;
  
    private Dictionary<string, Text> textComponents = new Dictionary<string, Text>();

    private GameObject toolTip;
    private Vector2 offset;
    private RectTransform rectTransform;

    private void Start()
    {
        createDictionary();
        toolTip = this.gameObject;

        rectTransform = GetComponent<RectTransform>();
        offset = new Vector2(1, 1); 
    }

    private void createDictionary()
    {
        //Get all the childs
        foreach(Transform transform in this.gameObject.transform)
        {
            string name = transform.gameObject.name;
            Text text = transform.gameObject.GetComponent<Text>();
            Image img = transform.gameObject.GetComponent <Image> ();

            if (text == null)
            {
                if (img != null)
                    image = img;

                continue;
            }     

            textComponents.Add(name, text);
        }

    }

    private void setData()
    {
        image.sprite = item.Sprite;
        textComponents["Title"].text = item.Name;
        textComponents["Stats"].text = "ID: " + item.ID + "\n" +
                                       "Type: " + item.Type + "\n";
    }


    private void Update()
    {
        if(toolTip.activeSelf)
        {
            toolTip.transform.position = Camera.main.ScreenToWorldPoint(InputBehaviour.MousePosition);
            Debug.Log(Camera.main.ScreenToWorldPoint(InputBehaviour.MousePosition));
        }
    }

    public void Show(Item item)
    {
        this.item = item;
        setData();
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
