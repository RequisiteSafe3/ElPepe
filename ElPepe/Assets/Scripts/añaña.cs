using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class añaña : MonoBehaviour
{
    Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity = new Vector2(-2, 0); //derecha
    }
}
