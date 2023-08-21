using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour, IDamageable
{   public bool disableSimulation = false;

    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;

    public bool canTurnInvincible = true;

    bool isAlive = true;
    bool Invincible = false;

    public float Health {
        set {
            if(value < _health) {
                animator.SetTrigger("hit");
            }
            _health = value;

            if (_health <= 0) {
                animator.SetBool("isAlive", false);
                Targetable = false;
            } //tener en cuenta si agregar "animator.SetTrigger("isAlive" = false);"
        }
        get {
            return _health;
        }
    }
    public bool Targetable { get {return _targetable;}
    set{
        _targetable = value;

        if(disableSimulation) {
            rb.simulated = false;
        }
        physicsCollider.enabled = value;
    }}
    
    public float _health = 5f;
    public bool _targetable = true;
    
    //agregue detectionzone y rigidbody2D
    //para tener en cuenta "bool isAlive = true;"
    //private void Start()
    public void Start(){
        animator = GetComponent<Animator>();

        animator.SetBool("isAlive", isAlive);

        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }
    //public void TakeDamage(float damage)
    //agregue rb.AddForce(knockback);
    //Debug.Log("Force" + knockback);
    //Vector2 knockback    
    public void OnHit(float damage, Vector2 knockback) 
    {
        if(!Invincible) {
            Health -= damage;
        
            rb.AddForce(knockback, ForceMode2D.Impulse);
        //Debug.Log("Force" + knockback);
            if(canTurnInvincible){
                Invincible = true;
            }
        }
    }
    public void OnHit(float damage)
    {
        if(!Invincible){
            Health -= damage;

            if(canTurnInvincible){
                Invincible = true;
            }
        }
    }   
    public void OnObjectDestroyed() 
    {
        Destroy(gameObject);
    }
}
