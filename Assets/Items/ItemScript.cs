using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public enum ItemList
    {
        Empty,
        Circle,
        Hexagon
    }
    int RnItem()
    {
        return Random.Range(1, 3);
    }
    void Start()
    {
        var i = RnItem();
        var s = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        s.sprite = Resources.Load<Sprite>(((ItemList)i).ToString());
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, (float)i);
        switch (i)
        {
            case 1:
                s.color = new Color(204, 51, 51);
                break;
            case 2:
                s.color = new Color(51, 51, 204);
                break;
            default:
                break;
        }
        
        
    }
}
