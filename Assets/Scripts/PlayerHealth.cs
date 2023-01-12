using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static int fullHP = 5;
    public int health = fullHP;
    
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Transform respawnPoint;

    // Update is called once per frame
    void Update()
    {
        // if died
        if (health <= 0)
        {
            Die();
        }
        
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
    /**
    * Causes the enemy entiy to take damage
    * @param damage the amount of damage taken int
    */
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    public void TakeDamage()
    {
        health -= 1;
    }
    /**
    *ON death event. Respawn player
    */
    void Die()
    {
        Debug.Log("You have Died");

        
        transform.position = respawnPoint.position; 
        health = 5;
    }
    /**
    IEnumerator playDeath() // doesnt work btw
    {
        gameObject.GetComponent<PlayerCombat>().Stunned = true;
        yield return new WaitForSeconds(deathTime);
        gameObject.GetComponent<PlayerCombat>().Stunned = false;
    }
    */
}
