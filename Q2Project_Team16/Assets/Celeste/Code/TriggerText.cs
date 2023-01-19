using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerText : MonoBehaviour
{
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            obj.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) => obj.SetActive(false);
}
