using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead_Movement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    //waypoints[0]: bot waypoints[1]: top

    [SerializeField] private int currentWaypointIndex = 0;
    //set waypoint direction

    [SerializeField] private float speed = 18f;

    [SerializeField] private float idle = 0f;

    private Animator anim;

   //[SerializeField] private Collider2D sensor;

   [SerializeField] private bool isTrigger = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(isTrigger == true)
        {
            if (idle < 2f)
            {
                idle = idle + (Time.deltaTime * 1f);

                if (idle >= 2f)
                {
                    anim.SetBool("aggro", true);

                    anim.SetBool("botHit", false);

                    anim.SetBool("topHit", false);
                }
            }
            else
            {
                if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
                {
                    if (currentWaypointIndex == 0)
                    {
                        anim.SetBool("botHit", true);
                    }
                    else if (currentWaypointIndex == 1)
                    {
                        anim.SetBool("topHit", true);
                    }

                    currentWaypointIndex++;
                    if (currentWaypointIndex >= waypoints.Length)
                    {
                        currentWaypointIndex = 0;
                        isTrigger = false;
                    }

                    idle = 0;

                    anim.SetBool("aggro", false);
                }
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
            isTrigger = true;
    }
}
