using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject Pausaa;
    private bool P = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (P == false) {
                Pausaa.gameObject.SetActive(true);
                Time.timeScale = 0.1F;
                P = true;
            }
            else
            {
                Continuar();
            }
        }
    }
    
    public void Continuar()
    {
        Pausaa.gameObject.SetActive(false);
        Time.timeScale = 1;
        P = false;
    }
    public void Menu(string NMenú)
    {
        SceneManager.LoadScene(NMenú);
    }
    
    public void Salir()
    {
        Application.Quit();
    }
}
