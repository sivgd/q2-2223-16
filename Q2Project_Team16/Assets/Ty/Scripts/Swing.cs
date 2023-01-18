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
    public BoxCollider2D bigCol, smallCol;
    public GameObject Player;
    public Animator animator;
 
    



    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        hj = gameObject.GetComponent<HingeJoint2D>();
        bigCol = GetComponent<BoxCollider2D>();
        smallCol = GetComponent<BoxCollider2D>();
    }

    //Update is called once per frame
    void Update()
    {
        CheckKeyboardInputs();
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
        if (smallCol.gameObject.tag == "Rope")
        {
            Debug.Log("1");
            bigCol.enabled = false;
            if (attachedTo != smallCol.gameObject.transform.parent)
            {
                Debug.Log("2");
                if (disregard == null || smallCol.gameObject.transform.parent.gameObject != disregard)
                {
                    Debug.Log("3");
                    Attach(smallCol.gameObject.GetComponent<Rigidbody2D>());
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Rope")
        {
            Detach();
        }
    }




    void Attach(Rigidbody2D ropeBone)
    {
    hj.connectedBody = ropeBone;
    hj.enabled = true;
    Player.GetComponent<Movement>().enabled = false;
    attached = true;
    attachedTo = ropeBone.gameObject.transform.parent;
    }


    void Detach()
    {
    attached = false;
    hj.enabled = false;
    Player.GetComponent<Movement>().enabled = true;
    //hj.connectedBody = null;
    bigCol.enabled = true;
    }
}
