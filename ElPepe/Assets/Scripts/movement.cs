using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    Rigidbody2D rb2D;

    //Public variables
    public SpriteRenderer spriteR;
    public Animator animator;
    public LayerMask groundLayer;
    public GameObject Arbolito;
    public GameObject ible;
    public GameObject time;
    public GameObject Activar_1;
    public GameObject Activar_2;

    //Adim variables
    public bool Intangible = false;
    public bool Mascara = false;


    //Private variables
    /*SerializeField is used to keep private variables visible in the
    unity inspector, remember that private variables are the first step to keep
    our code as clean as possible.*/
    [Header("Movement variables")]
    [SerializeField] private float runSpeed = 1.75f;
    [SerializeField] private float multiplierValue = 1.5f;
    [SerializeField] private float coyoteTime = 2f;
    private float coyoteTimeCounter;
    private float runMultiplier;
    private bool plantar = false;

    [Header("Jump variables")]
    [SerializeField] private int maxJumps = 1;     
    [SerializeField] private float jumpForce = 13;
    [SerializeField] private int jumpsLeft = 1;
    [SerializeField] private float jumpBreak = 0.4f;
    
    private BoxCollider2D boxCollider;
    public int E = 1;

    //Movimiento de la cámaraa
    public Cámara camara;

    //Starts
    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        jumpsLeft = maxJumps;
        jumpForce = 3.5f;
        camara = FindObjectOfType<Cámara>();
    }

    private void Update() {
        horizontalMovement();
        jumpMovement();
        if (groundChecker.isGrounded || rb2D.velocity.y == 0) {
            coyoteTimeCounter = coyoteTime;
        }
        else {
            coyoteTimeCounter -= Time.deltaTime;
        }

        //Opciones admin

        //intangible
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
    }

    void jumpMovement() {
        if (coyoteTimeCounter > 0f! & (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            jumpsLeft = maxJumps;
            coyoteTimeCounter = 0f;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && jumpsLeft > 0)
        {
            jumpsLeft = jumpsLeft - 1;
            //rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow)) && rb2D.velocity.y > 0f)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * jumpBreak);
        }
    }

    void horizontalMovement() {
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) { //Dont move when is pressing both keyes
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("idle", true);
            animator.SetBool("run", false);
            animator.SetBool("walk", false);
        }
        else {
            float movementInput = Input.GetAxis("Horizontal"); // Controls horizontal movement.
            if (Input.GetKey(KeyCode.W)) { // Running.
                runMultiplier = multiplierValue;
                animator.SetBool("walk", false); /* Animator */
                animator.SetBool("run", true); /* Animator */
            }
            else {
                runMultiplier = 1f;
                animator.SetBool("walk", true); /* Animator */
                animator.SetBool("run", false); /* Animator */
            }

            animator.SetBool("idle", false); /* Animator */
            rb2D.velocity = new Vector2(movementInput * runSpeed * runMultiplier, rb2D.velocity.y);

            if (rb2D.velocity.x < -0.1) { // Flip sprite manager.
                spriteR.flipX = true;
            }
            else if (rb2D.velocity.x > 0.1) {
                spriteR.flipX = false;
            }
            else if (rb2D.velocity.x == 0) { // Idle animation in case of not moving.
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
        Activar_1.gameObject.SetActive(true);
        Activar_2.gameObject.SetActive(true);
        Mascara = false;
    }

}