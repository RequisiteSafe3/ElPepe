using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class txt : MonoBehaviour
{
    private bool TRange = false;
    [SerializeField] private GameObject Object;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Object.gameObject.SetActive(true);
            TRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Object.gameObject.SetActive(false);
        TRange = false;
    }
}