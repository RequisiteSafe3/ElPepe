using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp : MonoBehaviour
{
    public Groundc GC;
    public Echo echo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && GC.isGrounded == true)
        {
            transform.position = new Vector3(echo.transform.position.x, echo.transform.position.y - 0.533f, echo.transform.position.z);
        }
    }
     public void InstaTP()
    {
        transform.position = new Vector3(echo.transform.position.x, echo.transform.position.y - 0.533f, echo.transform.position.z);
    }
}
