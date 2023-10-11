using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_properties : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    public void TakeDamage(float damage) {
        
        currentHealth -= damage;

        if(currentHealth <= 0) {
            Destroy(gameObject);
        }
    }
}
