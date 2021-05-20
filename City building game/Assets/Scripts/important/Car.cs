using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    public WayPoint NextWaypoint;
    public WayPoint LastWaypoint;

    public GameObject startWayPoint;


    public float speed = 20;
    private float actualSpeed;
    public float rotationTime = 300;

    void Start()
    {
        actualSpeed = speed;
        //NextWaypoint = startWayPoint.GetComponent<CarWayPoint>();
    }

    // Update is called once per frame
    void Update()
    {

        if (NextWaypoint != null && LastWaypoint != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, NextWaypoint.transform.position, actualSpeed * Time.deltaTime);

            Vector3 targetPoint = NextWaypoint.transform.position;

            var lookPos = targetPoint - transform.position;
            //lookPos.x = 0;


            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationTime * Time.deltaTime);


            if (transform.position == NextWaypoint.transform.position)
            {

                WayPoint c = NextWaypoint;
                var result = NextWaypoint.getNextWaypoint(LastWaypoint);
                NextWaypoint = result.Item1;
                if (result.Item2)
                {
                    actualSpeed = speed / 2;
                    LastWaypoint = c.secondWayPoint;

                }
                else
                {
                    LastWaypoint = c;
                    actualSpeed = speed;
                }
                /*
                CarWayPoint c = NextWaypoint;
                var result = NextWaypoint.getNextWaypoint(LastWaypoint);
                NextWaypoint = result.Item1;
                LastWaypoint = c;
                */

            }
        }
    }
}
