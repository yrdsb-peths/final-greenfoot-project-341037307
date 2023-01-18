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

    private float attackDuration = 0.5f;

    // Parry Variables
    public bool isParrying;
    public bool parryTriggered;
    private bool canParry = true;
    private float parryDuration = 0.5f;
    private float parryCD = 2f;
    private bool parryReset;
    // Stunned
    public bool Stunned; 
    public Animator animator;

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
        if (isParrying || Stunned)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= nextAttackTime)
            {
                Debug.Log("M1");
                StartCoroutine(Attack());
                nextAttackTime = Time.time + 1/attackRate;
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && canParry)
        {

            Debug.Log("Parry");
            StartCoroutine(Parry());
        }
        
    }

    /**
    * Start players attack
    */
    IEnumerator Attack()
    {
        // Play attack
        animator.SetBool("IsAttacking", true);
        // Detect attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // do dmg
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
        yield return new WaitForSeconds(attackDuration);
        animator.SetBool("IsAttacking", false);
    }
    /**
    * Draw attack radius in unity view
    */
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    /**
    *Gives parry frames to player
    **/
    IEnumerator Parry()
    {
        // Play Parry
        animator.SetBool("IsParrying", true);
        // Parry Effect
        canParry = false;
        isParrying = true;
        parryReset = false;
        yield return new WaitForSeconds(parryDuration);
        isParrying = false;
        animator.SetBool("IsParrying", false);
        yield return new WaitForSeconds(parryCD);
        if (!parryReset)
        {
            canParry = true;
        }

    }
}
