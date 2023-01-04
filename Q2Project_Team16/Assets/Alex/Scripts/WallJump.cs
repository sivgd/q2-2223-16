using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{

    public float distance;
    public Transform wallCheck;
    bool movingRight = true;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D wallInfo = Physics2D.Raycast(wallCheck.position, Vector2.right, distance);
        if (wallInfo.collider.CompareTag("Wall"))
        {
            Debug.Log("hi");
            //fix this
        }
    }
}
