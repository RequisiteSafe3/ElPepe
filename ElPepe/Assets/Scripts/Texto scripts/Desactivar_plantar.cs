using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivar_plantar : MonoBehaviour
{
    public GameObject Bolita;
    public Echo echo;
    private bool Borrar = false;
    private void Update()
    {
        if (Borrar == true && echo.Desactivar_Bolita_de_Plantar == true)
        {
            Bolita.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Borrar = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Borrar = false;
        }
    }
}
