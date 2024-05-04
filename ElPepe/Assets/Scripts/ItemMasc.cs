using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMasc : MonoBehaviour
{
    public GameObject Mascara;
    private float Posicion_X;
    private float Posicion_Y;
    private void Start()
    {
        Posicion_X = transform.position.x;
        Posicion_Y = transform.position.y;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine("Masc_");
        }
    }
    IEnumerator Masc_()
    {
        Mascara.gameObject.SetActive(false);
        transform.position = new Vector3(0f, 0f, transform.position.z);
        yield return new WaitForSecondsRealtime(10);
        Mascara.gameObject.SetActive(true);
        transform.position = new Vector3(Posicion_X, Posicion_Y, transform.position.z);
    }
}
