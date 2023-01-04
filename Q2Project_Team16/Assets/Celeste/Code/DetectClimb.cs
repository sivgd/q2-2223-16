using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectClimb : MonoBehaviour
{
    private float PlayerColHeight;
    private float PlayerColWidth;
    private bool Climb = false;


    void Start()
    {
        PlayerCol = GetComponent<CapsuleCollider2D>();
        PlayerColHeight = PlayerCol.bounds.size.y;
        PlayerColWidth = PlayerCol.bounds.size.x;
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (!IsGrounded() && (col.gameObject.tag == "Wall"))
        {
            Vector2 position = transform.position;
            Vector2 wallPos = col.transform.position;
            float wallColHeight = col.gameObject.GetComponent<BoxCollider2D>().bounds.size.y;
            if ((position.y + PlayerColHeight / 2) == (wallPos.y + wallColHeight / 2))
            {
                Climb = true;
            }
            Debug.Log(Climb);
        }
    }
}
