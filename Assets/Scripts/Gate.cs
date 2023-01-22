using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject[] KillReqs;
    // Update is called once per frame
    void Update()
    {
        bool alive = false;
        foreach(GameObject enemy in KillReqs) // loops thru all enemys in array
        {
            if (enemy != null)
            {
                alive = true;
            }
        }
        if (alive == false) // if all enemies are dead, open the gate
        {
            gameObject.SetActive(false); 
        }
    }
}
