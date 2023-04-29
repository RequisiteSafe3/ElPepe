using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mascara : MonoBehaviour
{
    public SpriteRenderer spriteR;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        { // Flip sprite manager.
            spriteR.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            spriteR.flipX = false;
        }
    }
}
