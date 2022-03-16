using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float mFrames = 0f;
    public float force = 15f;
    bool canMove;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0);
        Debug.Log(Input.mousePosition);
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                rb.AddForce(mousePos * force, ForceMode2D.Impulse);
                mFrames = 30;
            }
        }
    }

    void FixedUpdate()
    {
        if (mFrames <= 0)
        {
            canMove = true;
        }
        else 
        {
            mFrames--;
            canMove = false;
        }
    }
}
