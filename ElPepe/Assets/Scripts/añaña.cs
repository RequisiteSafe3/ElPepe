using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class añaña : MonoBehaviour
{
    [SerializeField] private float Velocidad;
    [SerializeField] private Transform[] Puntos;
    [SerializeField] private float Distancia;

    private int SiguientePaso = 0;
    private SpriteRenderer spriteR;
    void Start()
    {
       spriteR = GetComponent<SpriteRenderer>();
       Girar();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Puntos[SiguientePaso].position, Velocidad * Time.deltaTime);
        if (Vector2.Distance(transform.position, Puntos[SiguientePaso].position) < Distancia)
        {
            SiguientePaso++;
            if (SiguientePaso >= Puntos.Length)
            {
                SiguientePaso = 0;
            }
            Girar();
        }
    }
    public void Girar()
    {
        if (transform.position.x < Puntos[SiguientePaso].position.x)
        {
            spriteR.flipX = true;
        }
        else
        {
            spriteR.flipX = false;
        }
    }
}
