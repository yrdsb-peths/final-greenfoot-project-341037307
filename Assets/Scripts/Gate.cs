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
        foreach(GameObject enemy in KillReqs)
        {
            if (enemy != null)
            {
                alive = true;
            }
        }
        if (alive == false)
        {
            gameObject.SetActive(false);
        }
    }
}
