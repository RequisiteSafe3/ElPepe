using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivar_Filtro : MonoBehaviour
{
    public GameObject Empty;
    public GameObject Filtro_Ponido;
    public Echo echo;
    public Cambiar_Color color;
    public Cambiar_Color_ color_;
    private bool Puede_Poner = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Puede_Poner == true && echo.Filtros > 0)
        {
            echo.Bajar_Contador_De_Filtros();
            Filtro_Ponido.gameObject.SetActive(true);
            color.Cambiar();
            color_.Cambiar();
            Empty.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Puede_Poner = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Puede_Poner = false;
        }
    }
}
