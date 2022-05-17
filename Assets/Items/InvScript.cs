using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvScript : MonoBehaviour
{
    public static int[] Inventory = new int[2];
    private ItemScript.ItemList pItem = ItemScript.ItemList.Empty;
    private GameObject pItemObject;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "DroppedItem")
        {
            pItem = (ItemScript.ItemList)col.transform.position.z;
            pItemObject = col.gameObject;
            Debug.Log(pItem);
            if (AddItem(pItem))
            {
                Destroy(pItemObject);
                pItem = ItemScript.ItemList.Empty;
                pItemObject = null;
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "DroppedItem")
        {
            pItem = ItemScript.ItemList.Empty;
            pItemObject = null;
        }
    }
    void Start()
    {
        Inventory = new int[2];
    }
    bool AddItem(ItemScript.ItemList i)
    {
        switch (i)
        {
            case ItemScript.ItemList.Circle:
                Debug.Log("Circle " + Inventory.Length);
                Inventory[0]++;
                Camera.main.transform.GetChild(0).Find("Circle").GetChild(0).GetComponent<Text>().text = Inventory[0].ToString();
                return true;
            case ItemScript.ItemList.Hexagon:
                Debug.Log("Hexagon " + Inventory.Length);
                Inventory[1]++;
                Camera.main.transform.GetChild(0).Find("Hexagon").GetChild(0).GetComponent<Text>().text = Inventory[1].ToString();
                return true;
            default:
                return false;
        }
    }
}
