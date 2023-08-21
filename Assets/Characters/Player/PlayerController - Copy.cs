using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    bool IsMoving {
        set {
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
            //agregue un if
            if(isMoving) {
                rb.drag = moveDrag;
            }else{
                rb.drag = stopDrag;
            }
        }
    }

    public float moveSpeed = 1250f; //public float moveSpeed = 1f;
    public float moveDrag = 15f; //agregue maxspeed //public float maxSpeed = 8f;
    public float stopDrag = 25f; //public float idleFriction = 0.9f;
    //agregue public bool canAttack = true;
    public string attackAnimName = "swordAttack"; //agregue public string attackAnimName = "swordAttack";
    public GameObject swordHitbox;

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Collider2D swordCollider; 
    Vector2 moveInput = Vector2.zero; //Vector2 movementInput;

    bool isMoving = false; //agregue bool isMoving = false; 
    bool canMove = true;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // private void FixedUpdate()
    void FixedUpdate() {
        if(canMove == true && moveInput != Vector2.zero) {
            rb.AddForce(moveInput * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);

            //if(rb.velocity.magnitude > maxSpeed) {
               // float limitedSpeed = Mathf.Lerp(rb.velocity.magnitude, maxSpeed, idleFriction);
                //rb.velocity = rb.velocity.normalized * limitedSpeed;
           // }
            if(moveInput.x > 0) {
                spriteRenderer.flipX = false;
                gameObject.BroadcastMessage("IsFacingRight", true);
            } else if (moveInput.x < 0) {
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("IsFacingRight", false);
            }
            IsMoving = true;
        } else {
        // rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
            IsMoving = false;
        }
    }
    
    //private void OnMove(InputValue movementValue)
    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    void OnFire() {
        animator.SetTrigger("swordAttack");
    }

    void LockMovement() {
        canMove = false;
    }


    void UnlockMovement() {
        canMove = true;
    }
}
