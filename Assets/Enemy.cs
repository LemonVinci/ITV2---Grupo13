using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 2;

    Animator animator;

    public float Health {
        set {
            health = value;

            if (health <= 0) {
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    private void Start() {
        animator = GetComponent<Animator>();
    }
    
    public void TakeDamage(float damage) {
        Health -= damage;
        animator.SetTrigger("Damaged");
    }

    public void Defeated() {
        animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }
}
