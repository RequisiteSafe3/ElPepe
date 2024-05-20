using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class Stats : MonoBehaviour
{
    public Echo echo;
    public GameObject fondo;
    public int Buenas_Acciones = 0;

    public TextMeshProUGUI Filtros_Texto;
    public TextMeshProUGUI Aire_Texto;
    public TextMeshProUGUI Semillas_Texto;
    public TextMeshProUGUI Maquinaria_Texto;
    public TextMeshProUGUI Suelos_Texto;
    public TextMeshProUGUI Total_Texto;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fondo.gameObject.SetActive(true);
            Buenas_Acciones = echo.Filtros_Reparados + echo.Aire_Reparado + echo.Semillas_Plantadas + echo.Maquinaria_Apagada + echo.Suelo_Fertilizado;
            Filtros_Texto.text = echo.Filtros_Reparados.ToString("0");
            Aire_Texto.text = echo.Aire_Reparado.ToString("0");
            Semillas_Texto.text = echo.Semillas_Plantadas.ToString("0");
            Maquinaria_Texto.text = echo.Maquinaria_Apagada.ToString("0");
            Suelos_Texto.text = echo.Suelo_Fertilizado.ToString("0");
            Total_Texto.text = Buenas_Acciones.ToString("0");
            Time.timeScale = 0;
        }
    }
}
