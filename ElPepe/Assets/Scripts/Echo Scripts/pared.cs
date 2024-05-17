using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pared : MonoBehaviour
{
    public bool isTouchingWall_ = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isTouchingWall_ = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isTouchingWall_ = false;
        }
    }
}
