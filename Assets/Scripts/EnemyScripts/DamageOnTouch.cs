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
                player.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
            nextAttackTime = Time.time + 1/damageRate;
        }
    }
}
