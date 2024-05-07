using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivador1 : MonoBehaviour
{
    public GameObject BOLAVERDE;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BOLAVERDE.gameObject.SetActive(false);
        }
    }
}
