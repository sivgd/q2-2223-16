using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrigin : MonoBehaviour
{
    private Vector3 playerOrigin;
    public GameObject mainplayer;

    // Start is called before the first frame update
    void Start()
    {
        playerOrigin = mainplayer.transform.position;
        transform.localPosition = playerOrigin;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
