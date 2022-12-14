using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public SpriteRenderer sr;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveInput, 0, 0) * moveSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            sr.flipX = false;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            sr.flipX = true;
        }
    }

}
