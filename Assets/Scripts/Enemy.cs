using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    public GameObject player;
    public Collider2D enemyCollider;
    public Collider2D playerCollider;

    private float damageRate = 1;
    private float nextAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        

        if (enemyCollider.IsTouching(playerCollider) && Time.time >= nextAttackTime)
        {
            Debug.Log("We took damage");
            player.GetComponent<PlayerHealth>().TakeDamage();
            nextAttackTime = Time.time + 1/damageRate;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // Probably add knockback sometime
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy ded");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
