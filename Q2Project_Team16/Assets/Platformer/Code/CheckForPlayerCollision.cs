using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPlayerCollision : MonoBehaviour
{
    public GameObject spawnpoint;
    public GameObject mainPlayer;
    private Rigidbody2D rb2;
    AudioSource Enemysound;

    // Start is called before the first frame update
    void Start()
    {
        Enemysound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Respawn");
            rb2 = mainPlayer.GetComponent<Rigidbody2D>();
            rb2.velocity = new Vector2(0, 0);
           mainPlayer.transform.localPosition = spawnpoint.transform.localPosition;
            Enemysound.Play();
        }
    }


}
