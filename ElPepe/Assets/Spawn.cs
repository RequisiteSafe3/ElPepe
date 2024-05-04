using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private bool vagina = true;
    private void A()
    {
        item.gameObject.SetActive(true);
        vagina = false;
        StartCoroutine("e");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && vagina == true)
        {
            A();
        }
    }
    IEnumerator e()
    {
        yield return new WaitForSecondsRealtime(10);
        vagina = true;
    }
}
