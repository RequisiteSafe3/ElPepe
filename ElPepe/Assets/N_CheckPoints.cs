using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class N_CheckPoints : MonoBehaviour
{
    public TextMeshProUGUI Checkpoints_Texto;
    public Echo echo;
    private float Aux;
    void Start()
    {
        Checkpoints_Texto = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Actualizar()
    {
        Aux = echo.Checkpoints;
        Checkpoints_Texto.text = Aux.ToString("0");
    }
}
