using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRflip : MonoBehaviour
{

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            sr.flipX = false;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            sr.flipX = true;
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            sr.flipY = false;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            sr.flipY = true;
        }
    }
}