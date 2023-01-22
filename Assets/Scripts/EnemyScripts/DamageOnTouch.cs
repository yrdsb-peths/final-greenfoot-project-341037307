using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    public int damage = 1;
    public GameObject player;
    public Collider2D enemyCollider;
    public Collider2D playerCollider;
    private float damageRate = 1;
    private float nextAttackTime;

    void Update()
    {
        if (enemyCollider.IsTouching(playerCollider) && Time.time >= nextAttackTime) // if enemy collider is touching player collider and attack is not on Cooldown.
        {
            PlayerCombat PlrCombatScript = player.GetComponent<PlayerCombat>(); 
            //Debug.Log("We took damage");
            if (PlrCombatScript.isParrying) // if parrying, ignore
            {
                Debug.Log("Attack Parried");
                PlrCombatScript.parryTriggered = true;
            }
            else // if not parrying damage
            {
                Debug.Log("Player Damaged");
                player.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
            nextAttackTime = Time.time + 1/damageRate;
        }
    }
}
