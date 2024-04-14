using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Echo : MonoBehaviour
{
    public bool Intangible = false;
    public bool Mascara = false;
    public Animator animator;

    public GameObject Arbolito;
    public GameObject ible;
    public GameObject time;
    public GameObject m;
    public GameObject Checkpoint;

    private bool plantar = false;
    private float Posicion_X;
    private float Posicion_Y;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && Intangible == false)
        {
            Intangible = true;
        }
        else if (Input.GetKeyDown(KeyCode.I) && Intangible == true)
        {
            Intangible = false;
        }
        //plantar
        if (Input.GetKeyDown(KeyCode.E) && plantar == true)
        {
            Instantiate(Arbolito, new Vector3(transform.position.x, transform.position.y - 0.13f, -0.1f), Quaternion.identity);
        }

        //Checkpoint
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Posicion_X = transform.position.x;
            Posicion_Y = transform.position.y;
            Instantiate(Checkpoint, new Vector3(transform.position.x, transform.position.y - 0.13f, -0.1f), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.position = new Vector3(Posicion_X, Posicion_Y, transform.position.z);
        }

        //animaciones
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
        { //Dont move when is pressing both keyes
            animator.SetBool("idle", true);
            animator.SetBool("run", false);
            animator.SetBool("walk", false);
        }
        else
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            { // Running.
                if (Input.GetKey(KeyCode.W))
                { // Running.
                    animator.SetBool("idle", false);
                    animator.SetBool("walk", true); /* Animator */
                    animator.SetBool("run", false); /* Animator */
                }
                else
                {
                animator.SetBool("idle", false);
                animator.SetBool("walk", false); /* Animator */
                animator.SetBool("run", true); /* Animator */
                }
            }
            else
            { // Idle animation in case of not moving.
                animator.SetBool("walk", false); /* Animator */
                animator.SetBool("run", false); /* Animator */
                animator.SetBool("idle", true); /* Animator */
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead") && Intangible == false)
        {
            Debug.Log("sE MUERES");
        }
        else if (collision.CompareTag("masc"))
        {
            StartCoroutine("Mascara_");
            StartCoroutine("ani_");
        }
        else if (collision.CompareTag("humo") && Intangible == false && Mascara == false)
        {
            Debug.Log("sE MUERES");
        }
        else if (collision.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.CompareTag("arbol"))
        {
            plantar = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("arbol"))
        {
            plantar = false;
        }
    }
    IEnumerator Mascara_()
    {
        Mascara = true;
        ible.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(10);
        Masca();
    }
    IEnumerator ani_()
    {
        time.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(10.75f);
        time.gameObject.SetActive(false);
    }
    private void Masca()
    {
        ible.gameObject.SetActive(false);
        Mascara = false;
    }
}
