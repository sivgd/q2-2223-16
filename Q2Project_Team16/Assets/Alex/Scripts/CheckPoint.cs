using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public static Vector2 lastpos;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = lastpos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            lastpos = transform.position;
        }
    }
}
