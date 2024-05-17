using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Menu : MonoBehaviour
{
    public float rate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pz=Camera.main.ScreenToViewportPoint (Input.mousePosition);
        gameObject.transform.position = pz / rate;
    }
}
