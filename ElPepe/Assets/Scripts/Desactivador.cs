using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivador : MonoBehaviour
{
    public Echo echo;
    private bool Desactivar = false;
    public GameObject Taladro;
    public GameObject Luces;
    public GameObject Luz;
    void Update()
    {
        if (Desactivar == true && Input.GetKey(KeyCode.E))
        {
            echo.Maquinaria_Apagada++;
            Luces.gameObject.SetActive(false);
            Taladro.gameObject.SetActive(false);
            Luz.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            Desactivar = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Desactivar = false;
        }
    }
}

