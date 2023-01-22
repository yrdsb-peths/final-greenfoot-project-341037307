using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static int fullHP = 5;
    public int health = fullHP;
    
    public bool Cleansed;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Transform respawnPoint;

    public Animator animator;
    private float hitDuration = 0.5f;

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
    * Causes the enemy entiy to take damage. If no param is given, take one damage.
    * @param damage the amount of damage taken int
    */
    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(hitAnimation());
    }
    public void TakeDamage()
    {
        health -= 1;
        StartCoroutine(hitAnimation());
    }

    /**
    * Heals the player to full HP
    **/
    public void HealPlayer()
    {
        health = fullHP;
    }
    /**
    * Play hit duration for specificed time.
    **/
    IEnumerator hitAnimation()
    {
        animator.SetBool("Damaged", true);
        yield return new WaitForSeconds(hitDuration);
        animator.SetBool("Damaged", false);
    }
    /**
    *ON death event. Respawn player
    */
    void Die()
    {
        Debug.Log("You have Died");

        
        SceneManager.LoadScene("Over");
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
