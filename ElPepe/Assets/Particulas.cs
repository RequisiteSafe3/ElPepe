using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas : MonoBehaviour
{
    public GameObject Desactivar;
    void Start()
    {
        StartCoroutine("Particulas_");
    }
    IEnumerator Particulas_()
    {
        yield return new WaitForSecondsRealtime(2.9f);
        Destroy(Desactivar);
    }
}
