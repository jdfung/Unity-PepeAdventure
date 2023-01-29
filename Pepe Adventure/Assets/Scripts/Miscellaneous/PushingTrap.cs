using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingTrap : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    //waypoints[0]: left waypoints[1]: right

    [SerializeField] private int currentWaypointIndex = 0;
    //set waypoint direction

    [SerializeField] private float speed = 5f;

    [SerializeField] private float idleTime = 2f;

    private float idle = 0f;


    private Animator anim;

    //[SerializeField] private Collider2D sensor;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (idle < idleTime)
        {
            idle = idle + (Time.deltaTime * 1f);

            if (idle >= idleTime)
            {
                anim.SetBool("fire", true);
            }
        }
        else
        {
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;

                    idle = 0;

                    anim.SetBool("fire", false);
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
    }
}
