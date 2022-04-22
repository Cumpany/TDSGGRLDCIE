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
            Debug.Log(pItem);
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropInv();
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
            Debug.Log("Added " + i.ToString() + " to inventory (" + InvCount + ")");
            return true;
        }
        if (Inventory == i || Inventory == ItemScript.ItemList.Empty)
        {
            Inventory = i;
            InvCount++;
            Debug.Log("Added " + i.ToString() + " to inventory (" + InvCount + ")");
            return true;
        }
        Debug.Log("Could not add " + i.ToString() + " to inventory, it contains " + Inventory.ToString() + " (" + InvCount + ")");
        return false;
    }
    void DropInv()
    {
        if (InvCount > 0)
        {
            Vector3 pos = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f), 0);
            GameObject droppedItem = Instantiate(Resources.Load<GameObject>("DroppedItem"), pos, Quaternion.identity);
            droppedItem.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Inventory.ToString());
            droppedItem.transform.position = new Vector3(droppedItem.transform.position.x, droppedItem.transform.position.y, (float)Inventory);
            InvCount--;
            if (InvCount == 0)
            Inventory = ItemScript.ItemList.Empty;
        }
    }
}
