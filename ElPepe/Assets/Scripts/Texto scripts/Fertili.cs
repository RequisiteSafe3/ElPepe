using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fertili : MonoBehaviour
{
    public TextMeshProUGUI Fertilizante_Texto;
    public Echo echo;
    private float Aux;
    void Start()
    {
        Fertilizante_Texto = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Actualizar()
    {
        Aux = echo.Fertilizante;
        Fertilizante_Texto.text = Aux.ToString("0");
    }
}
