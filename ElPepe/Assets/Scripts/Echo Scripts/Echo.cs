using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Echo : MonoBehaviour
{
    public int Semillas = 0;
    public int Filtros = 0;
    public int Fertilizante = 0;
    public Semilli semilli;
    public Fertili fertili;

    public bool Intangible = false;
    public bool Mascara = false;
    public Animator animator;
    public Groundc GC;
    public Tp tp;

    public GameObject Arbolito;
    public GameObject ible;
    public GameObject time;
    public GameObject m;
    public Rigidbody2D rb2D;

    private bool plantar = false;
    private bool En_Zona_Infertil = false;
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
        if (Input.GetKeyDown(KeyCode.E) && plantar == true && Semillas > 0 && En_Zona_Infertil == false)
        {
            Instantiate(Arbolito, new Vector3(transform.position.x, transform.position.y - 1.002f, -0.1f), Quaternion.identity);
            Semillas--;
            semilli.Actualizar();
        }

        //Checkpoint
        if (Input.GetKeyDown(KeyCode.Q) && GC.isGrounded_ == true)
        {
            Posicion_X = transform.position.x;
            Posicion_Y = transform.position.y;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.position = new Vector3(Posicion_X, Posicion_Y, transform.position.z);
        }

        //animaciones
        if (rb2D.velocity.y > 0.1f)
        {
            animator.SetBool("jump", true);
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
            animator.SetBool("idle", false);
            animator.SetBool("Fall", false);
        }
        else if (rb2D.velocity.y < -0.1f)
        {
            animator.SetBool("Fall", true);
            animator.SetBool("jump", false);
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
            animator.SetBool("idle", false);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) {
            if (GC.isGrounded_){
                animator.SetBool("jump", false);
                animator.SetBool("idle", false);
                animator.SetBool("run", true);
                animator.SetBool("walk", false);
                animator.SetBool("Fall", false);
                if (Input.GetKey(KeyCode.W)) {
                    animator.SetBool("run", false);
                    animator.SetBool("walk", true);
                }
            }
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) {
            animator.SetBool("jump", false);
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
            animator.SetBool("idle", true);
            animator.SetBool("Fall", false);
        }
        else {
            animator.SetBool("jump", false);
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
            animator.SetBool("idle", true);
            animator.SetBool("JumpTop", false);
            animator.SetBool("Fall", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead") && Intangible == false && Mascara == false)
        {
            StartCoroutine("Muerte_");
        }
        else if (collision.CompareTag("masc"))
        {
            StartCoroutine("Mascara_");
            StartCoroutine("ani_");
        }
        else if (collision.CompareTag("humo") && Intangible == false && Mascara == false)
        {
            transform.position = new Vector3(182.516f, -16.51f, transform.position.z);
            Posicion_X = transform.position.x;
            Posicion_Y = transform.position.y;
            tp.InstaTP();
        }
        else if (collision.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collision.CompareTag("ZONA_INFERTIL"))
        {
            En_Zona_Infertil = true;
        }
        else if (collision.CompareTag("arbol"))
        {
            plantar = true;
        }
        else if (collision.CompareTag("Semillas"))
        {
            Semillas = Semillas + 5;
            semilli.Actualizar();
        }
        else if (collision.CompareTag("Filtro"))
        {
            Filtros++;
            //falta
        }
        else if (collision.CompareTag("Fertilizante"))
        {
            Fertilizante++;
            fertili.Actualizar();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("arbol"))
        {
            plantar = false;
        }
        else if (collision.CompareTag("ZONA_INFERTIL"))
        {
            En_Zona_Infertil = false;
        }
    }
    //Bajar contador de fertilizante
    public void Bajar_Contador_De_Fertilizante()
    {
        Fertilizante--;
        fertili.Actualizar();
    }
    IEnumerator Mascara_()
    {
        Mascara = true;
        ible.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(10);
        Masca();
    }
    IEnumerator Muerte_()
    {
        rb2D.constraints = RigidbodyConstraints2D.FreezePosition;
        animator.SetBool("Muerte", true);
        yield return new WaitForSecondsRealtime(.583f);
        transform.position = new Vector3(Posicion_X, Posicion_Y, transform.position.z);
        animator.SetBool("Muerte", false);
        rb2D.constraints = RigidbodyConstraints2D.None;
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb2D.rotation = 0;
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.02f, transform.position.z);
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
