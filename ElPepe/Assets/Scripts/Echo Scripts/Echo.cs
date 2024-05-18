using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Echo : MonoBehaviour
{
    public float Semillas = 0;
    public float Filtros = 0;
    public float Fertilizante = 0;
    public Semilli semilli;
    public Fertili fertili;
    public Filtrilli filtrilli;
    public N_CheckPoints CH;
    public bool Desactivar_Bolita_de_Plantar = false;
    public float Checkpoints = 3;

    public bool Intangible = false;
    public bool Mascara = false;
    public Animator animator;
    public Groundc GC;
    public pared pared;
    public Tp tp;

    public GameObject Arbolito;
    public GameObject time;
    public Rigidbody2D rb2D;
    public GameObject Animación_Fertilizante;
    public GameObject Animación_Semillas;
    public GameObject Animación_Filtro;

    private bool plantar = false;
    private bool En_Zona_Infertil = false;
    private float Posicion_X;
    private float Posicion_Y;
    void Start()

    {
        Debug.Log(Semillas);
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
            Checkpoints++;
            CH.Actualizar();
            StartCoroutine("Contador_de_Plantar_");
        }

        //Checkpoint
        if (Input.GetKeyDown(KeyCode.Q) && GC.isGrounded_ == true && Checkpoints > 0)
        {
            Posicion_X = transform.position.x;
            Posicion_Y = transform.position.y;
            Checkpoints--;
            CH.Actualizar();
        }
        if (Input.GetKeyDown(KeyCode.F) && GC.isGrounded_ == true)
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
            animator.SetBool("pared", false);
        }
        else if (!GC.isGrounded_ && pared.isTouchingWall_) {
            animator.SetBool("pared", true);
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
            animator.SetBool("idle", false);
            animator.SetBool("Fall", false);
            animator.SetBool("jump", false);
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
            if (rb2D.velocity.x != 0) {
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
            else {
                animator.SetBool("run", false);
                animator.SetBool("idle", true);
            }
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) {
            animator.SetBool("jump", false);
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
            animator.SetBool("idle", true);
            animator.SetBool("Fall", false);
            animator.SetBool("pared", false);
        }
        else {
            animator.SetBool("jump", false);
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
            animator.SetBool("idle", true);
            animator.SetBool("JumpTop", false);
            animator.SetBool("Fall", false);
            animator.SetBool("pared", false);
        }
        if (!pared.isTouchingWall_) animator.SetBool("pared", false);
        else if (pared.isTouchingWall_ && GC.isGrounded_) animator.SetBool("pared", false);
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
            Semillas = Semillas + 2.5f;
            StartCoroutine("Semillas_Anim_");
            semilli.Actualizar();
        }
        else if (collision.CompareTag("Filtro"))
        {
            Filtros = Filtros + .5f;
            StartCoroutine("Filtro_Anim_");
            filtrilli.Actualizar();
        }
        else if (collision.CompareTag("Fertilizante"))
        {
            Fertilizante = Fertilizante + .5f;
            StartCoroutine("Fertilizante_Anim_");
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
    //Animaciones de item
    IEnumerator Fertilizante_Anim_()
    {
        Animación_Fertilizante.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1.25f);
        Animación_Fertilizante.gameObject.SetActive(false);
    }
    IEnumerator Semillas_Anim_()
    {
        Animación_Semillas.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1.25f);
        Animación_Semillas.gameObject.SetActive(false);
    }
    IEnumerator Filtro_Anim_()
    {
        Animación_Filtro.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1.25f);
        Animación_Filtro.gameObject.SetActive(false);
    }
    //Bajar contador de fertilizante
    public void Bajar_Contador_De_Fertilizante()
    {
        Fertilizante--;
        fertili.Actualizar();
        Checkpoints++;
        CH.Actualizar();
    }
    //Bajar contador de filtros
    public void Bajar_Contador_De_Filtros()
    {
        Filtros--;
        filtrilli.Actualizar();
        Checkpoints++;
        CH.Actualizar();
    }
    IEnumerator Mascara_()
    {
        Mascara = true;
        yield return new WaitForSecondsRealtime(10);
        Masca();
    }
    IEnumerator Contador_de_Plantar_()
    {
        Desactivar_Bolita_de_Plantar = true;
        yield return new WaitForSecondsRealtime(1);
        Desactivar_Bolita_de_Plantar = false;
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
        Mascara = false;
    }
}
