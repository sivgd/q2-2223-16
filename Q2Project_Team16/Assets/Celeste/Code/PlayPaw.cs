using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPaw : MonoBehaviour
{
    public GameObject mainplayer;
    private Rigidbody2D rb2;
    public GameObject Bush;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Player")
        {
            Debug.Log("PlayPaw");
        }
    }
}
