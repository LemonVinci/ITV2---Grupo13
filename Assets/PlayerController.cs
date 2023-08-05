using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;

    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    public SwordAttack swordAttack;

    Vector2 movementInput;

    SpriteRenderer spriteRenderer;

    Rigidbody2D rb;

    Animator animator;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        if (canMove) {
            if (movementInput != Vector2.zero) {
                bool success = CanIMove(movementInput);

                if (!success) {
                    success = CanIMove(new Vector2(movementInput.x, 0));
                    if (!success) {
                        success = CanIMove(new Vector2(0, movementInput.y));
                    }
                }
                animator.SetBool("isMoving", success);
            } else {
                animator.SetBool("isMoving", false);
            }
            
            if (movementInput.x < 0) {
                spriteRenderer.flipX = true;
            } else if (movementInput.x > 0) {
                spriteRenderer.flipX = false;
            }
        }

    }

    private void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }

    private bool CanIMove(Vector2 direction) {
        if (direction != Vector2.zero) {
            int count = rb.Cast(
            movementInput,
            movementFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset
            );

            if (count == 0) {
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

    void OnFire() {
        animator.SetTrigger("swordAttack");
    }

    public void SwordAttack() {
        LockMovement();

        if (spriteRenderer.flipX == true) {
            swordAttack.AttackLeft();
        } else {
            swordAttack.AttackRight();
        }
    }

    public void EndSwordAttack() {
        UnlockMovement();
        swordAttack.StopAttack();
    }
    public void LockMovement() {
        canMove = false;
    }

    public void UnlockMovement() {
        canMove = true;
    }


}
