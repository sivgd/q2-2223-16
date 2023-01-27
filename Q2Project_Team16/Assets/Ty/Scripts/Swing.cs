using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public Rigidbody2D rb;
    private HingeJoint2D hj;

    public float pushForce = 10f;

    public bool attached = false;
    public Transform attachedTo;
    private GameObject disregard;
    public BoxCollider2D bigCol, smallCol, triggerCol;
    public GameObject Player;
    public Animator animator;
    public bool isOKtoAttach;





    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        hj = gameObject.GetComponent<HingeJoint2D>();
        bigCol = GetComponent<BoxCollider2D>();
        smallCol = GetComponent<BoxCollider2D>();
        isOKtoAttach = true;

    }

    private void Start()
    {
        //Invoke("TurnAttachTrue", 0.5f);
        //InvokeRepeating("TurnAttachTrue", 0f, 2f);
        //InvokeAfter("TurnAttachTrue")
        rb.freezeRotation = true;
    }

    //Update is called once per frame
    void Update()
    {
        CheckKeyboardInputs();

        if (attached == true)
        {
            animator.SetBool("Grabbing", true);
            animator.SetBool("Grounded", true);
        }
        else
        {
            animator.SetBool("Grabbing", false);
        }
    }

    void CheckKeyboardInputs()
    {
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            if (attached)
            {
                rb.AddRelativeForce(new Vector3(-1, 0, 0) * pushForce);
            }
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            if (attached)
            {
                rb.AddRelativeForce(new Vector3(1, 0, 0) * pushForce);
            }
        }
        if (Input.GetButtonDown("Jump") && attached)
        {
            Detach();
        }
    }


    void OnTriggerEnter2D(Collider2D smallCol)
    {
        if (isOKtoAttach == true)
        {
            if (smallCol.gameObject.tag == "Rope")
            {
                Debug.Log("1");
                if (attachedTo != smallCol.gameObject.transform.parent)
                {
                    Debug.Log("2");
                    //rb.freezeRotation = false;
                    bigCol.enabled = false;
                    if (disregard == null || smallCol.gameObject.transform.parent.gameObject != disregard)
                    {
                        Debug.Log("3");
                        Attach(smallCol.gameObject.GetComponent<Rigidbody2D>());
                    }
                }
            }
        }
    }




    void Attach(Rigidbody2D ropeBone)
    {
        {
            hj.connectedBody = ropeBone;
            hj.enabled = true;
            bigCol.enabled = false;
            Player.GetComponent<Movement>().enabled = false;
            attached = true;
            triggerCol.enabled = false;
        }
    }


    void Detach()
    {
        attached = false;
        hj.enabled = false;
        Player.GetComponent<Movement>().enabled = true;
        bigCol.enabled = true;
        isOKtoAttach = false;
        triggerCol.enabled = true;
        Invoke("TurnAttachTrue", 2.5f);
        //rb.freezeRotation = true;
    }


    void TurnAttachTrue()
    {
        isOKtoAttach = true;
    }
}
