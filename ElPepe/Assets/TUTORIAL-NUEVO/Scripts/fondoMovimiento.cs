using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fondoMovimiento : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMovimiento;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D Jrb2D;

    private void Awake() {
        material = GetComponent<SpriteRenderer>().material;
        Jrb2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update() {
        offset = (Jrb2D.velocity.x * 0.1f) * velocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset;

    }
}
