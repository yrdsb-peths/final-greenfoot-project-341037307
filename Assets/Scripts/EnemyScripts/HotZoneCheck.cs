using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour
{
    private MeleeEnemyAI enemyParent;
    private bool inRange;
    private Animator anim;

    // called once at run
    private void Awake()
    {
        enemyParent = GetComponentInParent<MeleeEnemyAI>();
        anim = GetComponentInParent<Animator>();
    }

    // Update called each frame
    private void Update()
    {
        if (inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            enemyParent.Flip();
        }
    }
    /**
    * On player collider erter, set inrange to true
    **/
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    /**
    * When player collider exits, deaggro NPC. Set in range to false, reanable trigger area, disable hotzone/
    **/
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            inRange = false;
            gameObject.SetActive(false);
            enemyParent.triggerArea.SetActive(true);
            enemyParent.inRange = false;
            enemyParent.SelectTarget();
        }
    }
}
