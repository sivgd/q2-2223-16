using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPos : MonoBehaviour
{

    public static Vector3 startPos;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        startPos = player.transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            player.transform.position = startPos;
        }
    }
}
