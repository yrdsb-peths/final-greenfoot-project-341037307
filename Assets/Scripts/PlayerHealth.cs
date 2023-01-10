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

    private int deathTime = 3;

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

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    public void TakeDamage()
    {
        health -= 1;
    }

    void Die()
    {
        Debug.Log("You have Died");

        
        transform.position = respawnPoint.position; 
        health = 5;
    }

    IEnumerator playDeath() // doesnt work btw
    {
        gameObject.GetComponent<PlayerCombat>().Stunned = true;
        yield return new WaitForSeconds(deathTime);
        gameObject.GetComponent<PlayerCombat>().Stunned = false;
    }
}
