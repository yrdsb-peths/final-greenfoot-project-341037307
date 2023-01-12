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
    //Update is called every frame
    void Update()
    {
        if (enemyCollider.IsTouching(playerCollider) && Time.time >= nextAttackTime)
        {
            PlayerCombat PlrCombatScript = player.GetComponent<PlayerCombat>();
            //Debug.Log("We took damage");
            if (PlrCombatScript.isParrying)
            {
                Debug.Log("Attack Parried");
                PlrCombatScript.parryTriggered = true;
            }
            else
            {
                Debug.Log("Player Damaged");
                player.GetComponent<PlayerHealth>().TakeDamage();
            }
            nextAttackTime = Time.time + 1/damageRate;
        }
    }

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
    }
}
