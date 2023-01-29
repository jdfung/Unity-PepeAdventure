using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI : MonoBehaviour
{
    //Reference to waypoints
    public List<Transform> points;
   
    //Integer value for the next poitn index
    public int nextID =0;
    //The values that appoint to ID for changing
    int idChangeValue = 1;
    [SerializeField] private float MovingSpeed;

    private void Reset()
    {
        Init();
    }

    void Init()
    {
        //Make box collider trigger
        GetComponent<BoxCollider2D>().isTrigger = true;

        //Create root object
        GameObject root = new GameObject(name + "Root ");

        //reset position of root to this enemy object
        root.transform.position = transform.position;
        //set enemy object as child of root 
        transform.SetParent(root.transform);
        //create waypoints object 
        GameObject waypoints = new GameObject("Waypoints");
        //reset waypoints position to root
        //Make waypoint object child of root
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        //create to point (gameobj) and reset their position to waypoints object
        //make the points children of waypoint
        GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform);p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2"); p2.transform.SetParent(waypoints.transform); p2.transform.position = root.transform.position;

        //Init points list then add the points to it
        points = new List<Transform>();

        points.Add(p1.transform);
        points.Add(p2.transform);
    }

    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        //Get to next point transform
        Transform goalPoint = points[nextID];
        //Flip the enemy to look into the point direction 
        if(goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //Move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, MovingSpeed * Time.deltaTime); 
        //Check the distance between enemy and goal point to trigger next point
        if(Vector2.Distance(transform.position,goalPoint.position)<0.1f)
        {
            //Check if we are at th end of the line(make the change -1)
            //2 point (0,1) next == point.count(2) -1
            if(nextID == points.Count -1)
            {
                idChangeValue = -1;
            }
            //Check if we are at the start of the line make the change +1
            if(nextID == 0)
            {
                idChangeValue = 1;
            }
            //Apply the change on the nextID
            nextID += idChangeValue;
            
        }
        
    }
}
