using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivar_Grid : MonoBehaviour
{
    public GameObject Grid;
    public Echo echo;
    public GameObject Particulas;
    private bool Puede_Borrar = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && Puede_Borrar == true && echo.Fertilizante > 0)
        {
            echo.Bajar_Contador_De_Fertilizante();
            Grid.gameObject.SetActive(false);
            StartCoroutine("Particulas_");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Puede_Borrar = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Puede_Borrar = false;
        }
    }
    IEnumerator Particulas_()
    {
        Particulas.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        Particulas.gameObject.SetActive(false);
    }
}
