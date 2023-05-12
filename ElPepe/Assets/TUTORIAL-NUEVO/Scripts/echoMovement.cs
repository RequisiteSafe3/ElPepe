using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class echoMovement : MonoBehaviour
{
    Rigidbody2D rb2D;

    //Public variables
    public SpriteRenderer spriteR;
    public Animator animator;
    public LayerMask groundLayer;
    public bool Mascara = false;
    public GameObject m;
    public GameObject ible;
    public GameObject testo;
    public GameObject time;
    public GameObject Arbolito;

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

    [Header("Jump variables")]
    [SerializeField] private int maxJumps = 1;     
    [SerializeField] private float jumpForce = 13;
    [SerializeField] private int jumpsLeft = 1;
    [SerializeField] private float jumpBreak = 0.4f;
    
    private BoxCollider2D boxCollider;
    public int E = 1;
    private bool plantar = false;

    //Movimiento de la cámaraa

    //Starts
    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        jumpsLeft = maxJumps;
    }

    private void Update() {
        horizontalMovement();
        jumpMovement();

        if (groundCheckerEcho.isGrounded || rb2D.velocity.y == 0) {
            coyoteTimeCounter = coyoteTime;
        }
        else {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (plantar == true)
        {
            Plantar();
        }
    }

    void jumpMovement() {
        if (coyoteTimeCounter > 0f !& (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))) {
            jumpsLeft = maxJumps;
            coyoteTimeCounter = 0f;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && jumpsLeft > 0) {
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
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) { // Not moving when pressing both keys.
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
        if (collision.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collision.CompareTag("Charco"))
        {
            transform.position = new Vector3(65.44f, 1.61f, 0);
        }
        else if (collision.CompareTag("Aña"))
        {
            transform.position = new Vector3(105.53f, 3.65f, 0);
        }
        else if (collision.CompareTag("humo") && Mascara == false) {
            transform.position = new Vector3(130.58f, -0.36f, 0);
            Instantiate(m, new Vector3(138.01f, -0.23f, -0.1f), Quaternion.identity);
            testo.gameObject.SetActive(true);
        }
        else if (collision.CompareTag("masc"))
        {
            StartCoroutine("Mascara_");
            StartCoroutine("ani_");
        }
        else if (collision.CompareTag("arbol"))
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
    private void Plantar()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(Arbolito, new Vector3(transform.position.x, transform.position.y - 0.9695f, -0.1f), Quaternion.identity);
        }
    }
}