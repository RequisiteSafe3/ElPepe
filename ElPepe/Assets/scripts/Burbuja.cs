using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burbuja : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float penesote;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Eliminar");
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity = new Vector2(0, .6f);
    }
    IEnumerator Eliminar()
    {
        yield return new WaitForSecondsRealtime(penesote);
        Crear();
    }
    private void Crear()
    {
        Destroy(this.gameObject);
    }
}
