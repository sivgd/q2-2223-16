using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movementScript : MonoBehaviour
{
    public Animator Animator;
    public GameObject player;
    public Rigidbody2D rb2d;
    public Vector3 movement;

    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(0f, Input.GetAxis("Vertical"), 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        float ymove = Input.GetAxis("Vertical");
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        float xmove = Input.GetAxis("Horizontal");
       
        if (ymove != 0)
        {
          
            Animator.SetBool("Ymove", true);
            Animator.SetBool("Idle", false);
            Animator.SetBool("Xmove", false);
        }
        else if (ymove == 0 && xmove == 0)
        {
            Animator.SetBool("Xmove", false);
            Animator.SetBool("Ymove", false);
            Animator.SetBool("Idle", true);
        }   
        else if (ymove == 1 && xmove == 0)
        {
            Animator.SetBool("Xmove", false); 
            Animator.SetBool("Ymove", true);
            Animator.SetBool("Idle", false);
        }

        if (xmove != 0)
        {
            Animator.SetBool("Xmove", true);
            Animator.SetBool("Idle", false);
            Animator.SetBool("Ymove", false);
        }
        else if (ymove == 0 && xmove == 1)
        {
            Animator.SetBool("Xmove", true);
            Animator.SetBool("Ymove", false);
            Animator.SetBool("Idle", false);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("Final MMMSMP");
        }
    }
}
