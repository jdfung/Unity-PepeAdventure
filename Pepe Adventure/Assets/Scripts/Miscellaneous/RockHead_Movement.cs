using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHead_Movement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    //waypoints[0]: left waypoints[1]: right

    [SerializeField] private int currentWaypointIndex = 0;
    //set waypoint direction

    [SerializeField] private float speed = 18f;

    [SerializeField] private float idle = 0f;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (idle < 2f)
        {
            idle = idle + (Time.deltaTime * 1f);

            if(idle >= 2f)
            {
                anim.SetBool("aggro", true);

                anim.SetBool("leftHit", false);

                anim.SetBool("rightHit", false);
            }
        }
        else
        {
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                if (currentWaypointIndex == 0)
                {
                    anim.SetBool("leftHit", true);
                }  
                else if (currentWaypointIndex == 1)
                {
                    anim.SetBool("rightHit", true);
                }

                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }

                idle = 0;

                anim.SetBool("aggro", false);
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
    }

}
