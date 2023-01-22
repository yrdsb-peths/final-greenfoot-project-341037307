using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerAI : MonoBehaviour
{
    public float moveSpeed;
    public GameObject[] wayPoints;

    int nextWayPoint = 1;
    float distToPoint; // distance to next waypoint
    
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /**
    * Move crawler to next waypoint Position
    **/
    void Move()
    {
        distToPoint = Vector2.Distance(transform.position, wayPoints[nextWayPoint].transform.position);

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[nextWayPoint].transform.position, moveSpeed * Time.deltaTime);

        if (distToPoint < 0.2f)
        {
            TakeTurn();
        }
    }

    /**
    *Rotates the crawler depending on the rotation of the waypoint
    **/
    void TakeTurn()
    {
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.z += wayPoints[nextWayPoint].transform.eulerAngles.z;
        transform.eulerAngles = currentRotation;
        ChooseNextWayPoint();
    }

    /**
    * Select the next waypoint.
    **/
    void ChooseNextWayPoint()
    {
        nextWayPoint++;
        if (nextWayPoint == wayPoints.Length)
        {
            nextWayPoint = 0;
        }
    }
}
