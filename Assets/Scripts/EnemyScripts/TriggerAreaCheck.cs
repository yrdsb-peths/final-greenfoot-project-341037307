using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaCheck : MonoBehaviour
{
    private MeleeEnemyAI enemyParent;
    private void Awake()
    {
        enemyParent = GetComponentInParent<MeleeEnemyAI>();
    }

    // when collider enters, check if it is player. If it is, set hotzone to active and aggro NPC.
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            enemyParent.target = collider.transform;
            enemyParent.inRange = true;
            enemyParent.hotZone.SetActive(true);
        }
    }
}
