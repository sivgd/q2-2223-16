using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public static Vector2 lastpos;
    public ParticleSystem activate;
    public ParticleSystem saved;
    public bool isSaved = false;
    public AudioSource chp;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = lastpos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            lastpos = transform.position;
            if (isSaved == false)
            {
                chp.Play();
                activate.Play();
                StartCoroutine(Delay());
                isSaved = true;
            }

        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        saved.Play();
    }
}
