using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    //Update is called every frame
    /**
    * Causes the enemy entiy to take damage
    * @param damage the amount of damage taken int
    */
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // Probably add knockback sometime
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /**
    *ON death event. Breaks collider
    */

    void Die()
    {
        Debug.Log("Enemy ded");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject);
    }
}
