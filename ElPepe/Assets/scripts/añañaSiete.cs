using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class añañaSiete : MonoBehaviour
{
    Rigidbody2D rb2D;
    public SpriteRenderer spriteR;
    public static bool x = true;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (x == true)
        {
            rb2D.velocity = new Vector2(-1.5f, 0); //derecha
            spriteR.flipX = false;
        }
        else
        {
            rb2D.velocity = new Vector2(1.5f, 0); //derecha
            spriteR.flipX = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mover"))
        {
            if (x == true)
            {
                x = false;
            }
            else
            {
                x = true;
            }
        }
    }
}
