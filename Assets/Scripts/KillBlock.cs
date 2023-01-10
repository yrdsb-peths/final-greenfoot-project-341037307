using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBlock : MonoBehaviour
{


    public void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("Trigger entered");
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().health = 0;
        }
    }
}
