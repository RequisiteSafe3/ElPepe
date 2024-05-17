using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cambio_De_Color : MonoBehaviour
{
    public TMP_Text TextM;
    void Start()
    {
        StartCoroutine("Blanco_");
    }
    IEnumerator Blanco_()
    {
        TextM.color = Color.white;
        yield return new WaitForSecondsRealtime(1.5f);
        StartCoroutine("Negro_");
    }
    IEnumerator Negro_()
    {
        TextM.color = Color.black;
        yield return new WaitForSecondsRealtime(1.5f);
        StartCoroutine("Blanco_");
    }
}
