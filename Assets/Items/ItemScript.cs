using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public enum ItemList
    {
        Empty,
        Circle,
        Hexagon,
        Diamond
    }
    int RnItem()
    {
        return Random.Range(1, 4);
    }
    void Awake()
    {
        var i = RnItem();
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(((ItemList)i).ToString());
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, (float)i);
    }
}
