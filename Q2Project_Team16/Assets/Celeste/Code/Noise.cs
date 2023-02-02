using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
    public AudioClip Noises;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(Noises, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
