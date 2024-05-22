using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp : MonoBehaviour
{
    public Groundc GC;
    public Echo echo;
     public void InstaTP()
    {
        transform.position = new Vector3(echo.transform.position.x, echo.transform.position.y - 0.533f, echo.transform.position.z);
    }
    public void actualizas_bandera()
    {
        transform.position = new Vector3(echo.transform.position.x, echo.transform.position.y - 0.533f, echo.transform.position.z);
    }
}
