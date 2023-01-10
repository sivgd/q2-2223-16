using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public GameObject obj;
    public GameObject player;
    public ParticleSystem ps;
    public ParticleSystem jumpReady;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && obj.GetComponent<Renderer>().enabled == true)
        {
            obj.GetComponent<Renderer>().enabled = false;
            player.GetComponent<Movement>().jumpForce = 16;
            StartCoroutine(Delay());
            ps.Stop();
            jumpReady.Play();
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        obj.GetComponent<Renderer>().enabled = true;
        ps.Play();
    }

}
