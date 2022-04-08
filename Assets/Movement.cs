using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float mFrames = 0f;
    public float force = 15f;
    bool canMove;
    public GameObject explosion;

    public float Velocity;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Velocity = Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y);
        Vector3 mousePos = new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0);
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                rb.AddForce(mousePos * force, ForceMode2D.Impulse);
                mFrames = 30;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && Velocity >= 10)
        {
            Instantiate(explosion, new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y, -1), transform.rotation);
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Enemy" && Velocity < 10)
        {
            Application.Quit(69);
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
