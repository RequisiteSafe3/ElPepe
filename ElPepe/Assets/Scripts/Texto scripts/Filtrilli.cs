using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Filtrilli : MonoBehaviour
{
    public TextMeshProUGUI Filtros_Texto;
    public Echo echo;
    private int Aux;
    void Start()
    {
        Filtros_Texto = GetComponent<TextMeshProUGUI>();
    }

    public void Actualizar()
    {
        Aux = echo.Filtros;
        Filtros_Texto.text = Aux.ToString("0");
    }
}