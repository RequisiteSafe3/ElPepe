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

    //Adim variables
    public bool Intangible = false;


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
    [SerializeField] private float jumpForce = 6;
    [SerializeField] private int jumpsLeft = 1;
    
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

        if (groundChecker.isGrounded) {
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
        //Niveles
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camara.E1();
            E = 1;
            transform.position = new Vector3(-3.388f, 1.84f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camara.E2();
            E = 2;
            transform.position = new Vector3(4.609963f, -1.516658f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            camara.E3();
            E = 3;
            transform.position = new Vector3(13.23f, -1.499f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            camara.E4();
            E = 4;
            transform.position = new Vector3(22.06f, -1.499f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            camara.E5();
            E = 5;
            transform.position = new Vector3(-3.404f, -3.879f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            camara.E6();
            E = 6;
            transform.position = new Vector3(4.877f, -6.467f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            camara.E7();
            E = 7;
            transform.position = new Vector3(13.326f, -6.478f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            camara.E8();
            E = 8;
            transform.position = new Vector3(21.876f, -3.903f, 0);
        }
    }

    void jumpMovement() {
        if(coyoteTimeCounter > 0f !& Input.GetKeyDown(KeyCode.Space)) {
            jumpsLeft = maxJumps;
            coyoteTimeCounter = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0) {
            jumpsLeft = jumpsLeft - 1;
            //rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }    
        if (Input.GetKeyUp(KeyCode.Space) && rb2D.velocity.y > 0f) {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.4f);
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
        if (collision.CompareTag("E1"))
        {
            camara.E1();
            E = 1;
        }
        else if (collision.CompareTag("E2"))
        {
            camara.E2();
            E = 2;
        }
        else if (collision.CompareTag("E3"))
        {
            camara.E3();
            E = 3;
        }
        else if (collision.CompareTag("E4"))
        {
            camara.E4();
            E = 4;
        }
        else if (collision.CompareTag("E5-"))
        {
            camara.E5();
            transform.position = new Vector3(-3.855f, -3.897f, 0);
            E = 5;
        }
        else if (collision.CompareTag("E5"))
        {
            camara.E5();
            E = 5;
        }
        else if (collision.CompareTag("E6"))
        {
            camara.E6();
            E = 6;
        }
        else if (collision.CompareTag("E7"))
        {
            camara.E7();
            E = 7;
        }
        else if (collision.CompareTag("E8"))
        {
            camara.E8();
            E = 8;
        }

        else if (collision.CompareTag("Dead") && Intangible == false)
        {
            if (E == 1)
            {
                transform.position = new Vector3(-3.388f, 1.84f, 0);
            }
            else if (E == 2)
            {
                transform.position = new Vector3(4.609963f, -1.516658f, 0);
            }
            else if (E == 3)
            {
                transform.position = new Vector3(13.23f, -1.499f, 0);
            }
            else if (E == 4)
            {
                transform.position = new Vector3(22.06f, -1.499f, 0);
            }
            else if (E == 5)
            {
                transform.position = new Vector3(-3.404f, -3.879f, 0);
            }
            else if (E == 6)
            {
                transform.position = new Vector3(4.877f, -6.467f, 0);
            }
            else if (E == 7)
            {
                transform.position = new Vector3(13.326f, -6.478f, 0);
            }
            else if (E == 8)
            {
                transform.position = new Vector3(21.876f, -3.903f, 0);
            }
        }
        else if (collision.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}