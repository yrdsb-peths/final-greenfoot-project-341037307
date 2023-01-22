using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBlock : MonoBehaviour
{
    public GameObject player;
    public Collider2D enemyCollider;
    public Collider2D playerCollider;

    private float damageRate = 1;
    private float nextAttackTime;
    void Update()
    {
        if (enemyCollider.IsTouching(playerCollider) && Time.time >= nextAttackTime) // on touch, heal player
        {
            player.GetComponent<PlayerHealth>().HealPlayer();
            nextAttackTime = Time.time + 1/damageRate; // Cooldown
        }
    }
}
