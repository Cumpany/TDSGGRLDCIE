using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvScript : MonoBehaviour
{
    public ItemScript.ItemList Inventory = ItemScript.ItemList.Empty;
    public int InvCount = 0;
    private ItemScript.ItemList pItem = ItemScript.ItemList.Empty;
    private GameObject pItemObject;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "DroppedItem")
        {
            pItem = (ItemScript.ItemList)col.transform.position.z;
            pItemObject = col.gameObject;
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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && AddItem(pItem))
        {
            Destroy(pItemObject);
            pItem = ItemScript.ItemList.Empty;
            pItemObject = null;
        }
    }
    void PickupItem(Collider2D col)
    {
        if (AddItem((ItemScript.ItemList)col.transform.GetChild(0).position.z))
        Destroy(col);
    }
    bool AddItem(ItemScript.ItemList i)
    {
        if (Inventory == i)
        {
            InvCount++;
        }
        if (Inventory == i || Inventory == ItemScript.ItemList.Empty)
        {
            Inventory = i;
            InvCount++;
            return true;
        }
        return false;
    }
}
