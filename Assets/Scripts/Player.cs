using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0;
    public Transform[] waypoints;

    private Transform target;

    public Transform initial;

    private int destPoint;

    private void Start()
    {
        target = waypoints[0];
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (transform.position == initial.position)
            {
                transform.position = waypoints[0].position;
            }
            else
            {
              Move();
            }

        }
        else
        {
            
                transform.position = initial.position;
                target = waypoints[0];
            
        }

    }

    private void Move()
    {
        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized*speed*Time.deltaTime, Space.World);

        //Si la main est quasiment arivé à la destination
        
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
             destPoint = (destPoint + 1) % waypoints.Length;
                target = waypoints[destPoint];
        }
        
     
    }

}

