using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Semilli : MonoBehaviour
{
    public TextMeshProUGUI Semillas_Texto;
    public Echo echo;
    private int Aux;
    void Start()
    {
        Semillas_Texto = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Actualizar()
    {
        Aux = echo.Semillas;
        Semillas_Texto.text = Aux.ToString("0");
    }
}
