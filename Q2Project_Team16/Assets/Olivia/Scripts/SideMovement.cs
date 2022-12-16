using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovement : MonoBehaviour
{
    public float accel = 8;
    private Rigidbody2D rb2;
    private SpriteRenderer sr;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal")>0)
        {
            sr.flipX = false;
            rb2.AddForce(new Vector2(accel, 0));
        }
        if (Input.GetAxis("Horizontal")<0)
        {
            sr.flipX = true;
            rb2.AddForce(new Vector2(-accel, 0));
        }
    }
}
