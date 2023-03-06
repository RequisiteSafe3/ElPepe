using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] private float runSpeed = 2;
    [SerializeField] private float multiplierValue = 1.5f;
    private float runMultiplier;

    [Header("Jump variables")]
    [SerializeField] private int maxJumps = 1;     
    [SerializeField] private float jumpForce = 3;
    [SerializeField] private int jumpsLeft = 1;

    [Header("Dash")]
    [SerializeField] private float dashJump;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashGravity;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float maxFallingSpeed;
    private bool canDash = true;
    private bool isDashing;
    
    [SerializeField] private TrailRenderer tr;
    private BoxCollider2D boxCollider;

    //Start
    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        jumpsLeft = maxJumps;
        jumpForce = 3;
    }

    private void Update() {
        horizontalMovement();
        jumpMovement();
        if (isDashing) {
            return;
        }
    }

    void jumpMovement() {
        if(groundChecker.isGrounded !& Input.GetKeyDown(KeyCode.Space)) {
            jumpsLeft = maxJumps;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0) {
            jumpsLeft = jumpsLeft - 1;
            if (!isDashing) {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0f);
            }
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }    
        if (rb2D.velocity.y <= -maxFallingSpeed && isDashing) {
            if (!Input.GetKey(KeyCode.S)) {
                rb2D.velocity = new Vector2(rb2D.velocity.x, -maxFallingSpeed); 
                rb2D.gravityScale = dashGravity;
            }   
            else {
                rb2D.gravityScale = dashGravity * 2;
            }
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
                if (isDashing) { // Dashing.
                    runMultiplier = multiplierValue * 1.25f;
                    animator.SetBool("walk", false); /* Animator */
                    animator.SetBool("run", true); /* Animator */
                }
            }
            else if (isDashing) { // Dashing.
                runMultiplier = multiplierValue * 1.2f; /* Dashing speed multiplier */
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

            if (Input.GetKey(KeyCode.LeftShift) && canDash) { // Dash.
                StartCoroutine(Dash());
            }

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

    private IEnumerator Dash() {
        canDash = false;
        isDashing = true;
        maxJumps = maxJumps + 1;
        float oG = rb2D.gravityScale; //oG means original gravity, just a personal adjustment. :)
        rb2D.gravityScale = dashGravity;
        jumpForce = (jumpForce / dashJump);
        tr.emitting = true; //Turns te trail on.
        yield return new WaitForSeconds(dashTime); //yield return makes the co-routine to not last forever, we assign the time by creating a timer by seconds.
        tr.emitting = false;
        isDashing = false;
        rb2D.gravityScale = oG;
        jumpForce = (jumpForce * dashJump);
        maxJumps = maxJumps - 1;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
