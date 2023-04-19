using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundChecker : MonoBehaviour
{
    public static bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    { // CheckGround.
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Tocando");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        Debug.Log("No tocando");
    }
}