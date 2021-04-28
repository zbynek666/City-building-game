using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    public CarWayPoint NextWaypoint;
    public CarWayPoint LastWaypoint;

    public GameObject startWayPoint;


    public float speed = 1.0f;

    void Start()
    {
        //NextWaypoint = startWayPoint.GetComponent<CarWayPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, NextWaypoint.transform.position, step);
        if (transform.position == NextWaypoint.transform.position)
        {
            CarWayPoint c = NextWaypoint;
            NextWaypoint = NextWaypoint.getNextWaypoint(LastWaypoint);
            LastWaypoint = c;
        }
    }
}
