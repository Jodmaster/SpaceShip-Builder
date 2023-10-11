using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_properties : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float damage = 5f;
    Rigidbody2D rigidBody;


    private void Start() {
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity =  transform.up * bulletSpeed;
        Physics2D.IgnoreLayerCollision(3,6,true);

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Enemy_properties enemy = collision.GetComponent<Enemy_properties>();

        if(enemy != null) {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
