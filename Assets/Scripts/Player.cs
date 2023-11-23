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

    public static float pettingTimmer;
    public static bool isPetting = false;
    public static bool isMono;

    private bool action = false;


    private void Start()
    {
        target = waypoints[0];
    }

    private void Update()
    {   
        CheckButton();
        if (action)
        {
            isPetting = true;
            if (transform.position == initial.position)
            {
                transform.position = waypoints[0].position;
            }
            else
            {
              Move();
            }
            pettingTimmer += Time.deltaTime;
            

        }
        else
        {
                SetPetStatus();
                transform.position = initial.position;
                target = waypoints[0];
                pettingTimmer = 0;
                isPetting = false;
            
        }

    }

    void CheckButton(){
        if (Input.GetKeyDown(KeyCode.Space)){
            action = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space)){
            action = false;
        }
    }

    void SetPetStatus(){
        if(Player.pettingTimmer >= 0.3){
            isMono=false;
        }
        else{
            isMono = true;
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


