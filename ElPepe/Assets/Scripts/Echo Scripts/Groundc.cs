using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundc : MonoBehaviour
{
    public bool isGrounded_ = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded_ = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded_ = false;
        }
    }
}
