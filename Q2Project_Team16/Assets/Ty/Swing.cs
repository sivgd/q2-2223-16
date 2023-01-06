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
    public BoxCollider2D col;
    public GameObject Player;
    



    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        hj = gameObject.GetComponent<HingeJoint2D>();
        col = GetComponent<BoxCollider2D>();
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


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Rope")
        {
            Debug.Log("1");
            if (attachedTo != col.gameObject.transform.parent)
            {
                Debug.Log("2");
                if (disregard == null || col.gameObject.transform.parent.gameObject != disregard)
                {
                    Debug.Log("3");
                    Attach(col.gameObject.GetComponent<Rigidbody2D>());
                }
            }
        }
    }






    void Attach(Rigidbody2D ropeBone)
    {
    ropeBone.gameObject.GetComponent<RopeSegment>().isPlayerAttached = true;
    hj.connectedBody = ropeBone;
    hj.enabled = true;
    attached = true;
    attachedTo = ropeBone.gameObject.transform.parent;
    }


    void Detach()
    {
    hj.connectedBody.gameObject.GetComponent<RopeSegment>().isPlayerAttached = false;
    attached = false;
    hj.enabled = false;
    hj.connectedBody = null;
    }
}
