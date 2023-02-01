using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public Collider2D col;
    Animator animator;
    public ParticleSystem jumpReady;
    public ParticleSystem dust;
    public bool isAlive;
    public Swing sw;
    public AudioSource source;
    public AudioClip boing;
    public AudioClip fall;
    public AudioClip monkey;
    public AudioClip ribbit;
    public bool alreadyPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        animator = gameObject.GetComponent<Animator>();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("yVelocity", rb.velocity.y);
        float moveInput = Input.GetAxisRaw("Horizontal");
        if(isAlive == true)
        {
            transform.position += new Vector3(moveInput, 0, 0) * moveSpeed * Time.deltaTime;
        }

        if (moveInput == 0)
        {
            animator.SetBool("Moving", false);
        }
        else
        {
            animator.SetBool("Moving", true);
        }

        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            animator.SetBool("Grounded", true);
            sw.isOKtoAttach = true;
            if (Input.GetKeyDown(KeyCode.Space) && isAlive == true)
            {
                CreateDust();
                source.PlayOneShot(boing);
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                if (jumpForce > 11)
                {
                    jumpForce = 11;
                    jumpReady.Stop();
                }
            }
            
        }
        else
        {
            animator.SetBool("Grounded", false);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            sr.flipX = false;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            sr.flipX = true;
        }

        if (animator.GetBool("Dead"))
        {
            isAlive = false;
        }
    }

    void CreateDust()
    {
        dust.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pit" && alreadyPlayed == false)
        {
            source.PlayOneShot(fall);
            source.PlayOneShot(monkey);
            alreadyPlayed = true;
        }
        if (collision.tag == "Enemy" && alreadyPlayed == false)
        {
            source.PlayOneShot(ribbit);
            alreadyPlayed = true;
        }
    }
}