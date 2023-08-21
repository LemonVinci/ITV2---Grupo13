using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public float swordDamage = 0.5f;//agregue "f"
    public float knockbackForce = 500f; //agregue public float knockbackForce = 500f;
    public Collider2D swordCollider;//public Collider2D swordCollider;
    public Vector3 faceRight = new Vector3(1, -0.05f, 0);
    public Vector3 faceLeft = new Vector3(-1, -0.05f, 0);

    void Start() {
        if(swordCollider == null){
            Debug.LogWarning("Sword Collider not set");
        }
    }


//private void OnTriggerEnter2D(Collider2D other)
//collider = other
    void OnTriggerEnter2D(Collider2D collider) {
        IDamageable damagableObject = collider.GetComponent<IDamageable>();

        if(damagableObject != null) {

            Vector3 parentPosition = transform.parent.position;

            Vector2 direction = (collider.transform.position - parentPosition).normalized;

            Vector2 knockback = direction * knockbackForce;

            damagableObject.OnHit(swordDamage, knockback);
        
        }
    }
    void IsFacingRight(bool isFacingRight) {
        if(isFacingRight) {
            gameObject.transform.localPosition = faceRight;
        } else {
            gameObject.transform.localPosition = faceLeft;
        }
    } 
}
