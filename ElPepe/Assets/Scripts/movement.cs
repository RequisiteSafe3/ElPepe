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

    //Private variables
    /*SerializeField is used to keep private variables visible in the
    unity inspector, remember that private variables are the first step to keep
    our code as clean as possible.*/
    [Header("Movement variables")]
    [SerializeField] private float runSpeed = 1.75f;
    [SerializeField] private float multiplierValue = 1.5f;
    private float runMultiplier;

    [Header("Jump variables")]
    [SerializeField] private int maxJumps = 1;     
    [SerializeField] private float jumpForce = 6;
    [SerializeField] private int jumpsLeft = 1;
    
    private BoxCollider2D boxCollider;
    public int E = 1;

    //Movimiento de la cámaraa
    public Cámara camara;

    //Start
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
        }
    

    void jumpMovement() {
        if(groundChecker.isGrounded !& Input.GetKeyDown(KeyCode.Space)) {
            jumpsLeft = maxJumps;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0) {
            jumpsLeft = jumpsLeft - 1;
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
        else if (collision.CompareTag("E5"))
        {
            camara.E5();
            E = 5;
        }

        else if (collision.CompareTag("Dead"))
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
        }
        else if (collision.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}