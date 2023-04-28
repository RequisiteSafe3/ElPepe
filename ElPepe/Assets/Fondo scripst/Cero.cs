using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cero : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float runSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }
        else
        {
            float movementInput = Input.GetAxis("Horizontal");
            rb2D.velocity = new Vector2(movementInput * runSpeed, rb2D.velocity.y);
        }
    }
}
