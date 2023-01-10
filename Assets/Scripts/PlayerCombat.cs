using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Attack Variables
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public float attackRate = 0.8f; // amount of attacks per second
    float nextAttackTime = 0f;

    // Parry Variables
     public bool isParrying;
     public bool parryTriggered;
     private bool canParry = true;
     private float parryDuration = 0.5f;
     private float parryCD = 2f;
     private bool parryReset;
     
    // Update is called once per frame
    void Update()
    {
        
        // Parry reset
        if (isParrying && parryTriggered)
        {
            parryTriggered = false;
            parryReset = true;
            canParry = true;
            Debug.Log("Parry Triggered");
        }
        // Control Variables
        if (isParrying)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= nextAttackTime)
            {
                Debug.Log("M1");
                Attack();
                nextAttackTime = Time.time + 1/attackRate;
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && canParry)
        {

            Debug.Log("Parry");
            StartCoroutine(Parry());
        }
        
    }

    void Attack()
    {
        // Play attack

        // Detect attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


        // do dmg
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator Parry()
    {
        // Play Parry

        // Parry Effect
        canParry = false;
        isParrying = true;
        parryReset = false;
        yield return new WaitForSeconds(parryDuration);
        isParrying = false;
        yield return new WaitForSeconds(parryCD);
        if (!parryReset)
        {
            canParry = true;
        }

    }
}
