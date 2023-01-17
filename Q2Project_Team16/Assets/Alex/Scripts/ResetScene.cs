using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public Animator anim;
    public Animator player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.SetBool("Dead", true);
            StartCoroutine(Delay());
            //PLEASE WORK OH MY GODDDDDDDDDDDDDDDDDDDDDDDDDDDD
        }
    }
IEnumerator Delay()
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
