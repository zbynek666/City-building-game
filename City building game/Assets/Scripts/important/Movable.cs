using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public WayPoint NextWaypoint;
    public WayPoint LastWaypoint;



    public float speed = 20;
    private float actualSpeed;
    public float rotationTime = 300;
    private Vector3 line = new Vector3(0, 0, 0);
    public int linesize;
    private bool jump = false;
    public bool canJump = false;
    // Start is called before the first frame update
    void Start()
    {
        actualSpeed = speed;

    }

    // Update is called once per frame
    void Update()
    {
        if (NextWaypoint != null && LastWaypoint != null)
        {



            // car rotation
            transform.position = Vector3.MoveTowards(transform.position, NextWaypoint.transform.position + line, speed * Time.deltaTime);

            Vector3 targetPoint = NextWaypoint.transform.position + line;

            var lookPos = targetPoint - transform.position;

            Quaternion rotation = new Quaternion();
            if (lookPos != Vector3.zero)
            {
                rotation = Quaternion.LookRotation(lookPos);
            }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationTime * Time.deltaTime);


            float rotY = transform.rotation.eulerAngles.y;
            if (rotY > 315 || rotY <= 45)
            {
                line = new Vector3(linesize, 0, 0);
            }
            else if (rotY > 45 && rotY <= 135)
            {
                line = new Vector3(0, 0, -linesize);

            }
            else if (rotY > 135 && rotY <= 225)
            {
                line = new Vector3(-linesize, 0, 0);

            }
            else if (rotY > 225 && rotY <= 315)
            {
                line = new Vector3(0, 0, linesize);

            }


            //setting current line 

            if (transform.position == NextWaypoint.transform.position + line)
            {



                List<WayPoint> waypoints = NextWaypoint.getWaypointsAround();








                if (waypoints.Count == 1)
                {
                    if (jump == false && canJump)
                    {
                        transform.position = NextWaypoint.transform.position + -line;
                        jump = true;
                    }
                    transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 10, transform.rotation.eulerAngles.z);
                    LastWaypoint = NextWaypoint;
                    NextWaypoint = waypoints[0];


                }

                else if (waypoints.Count >= 2 && waypoints.Count <= 4)
                {
                    waypoints.Remove(LastWaypoint);

                    LastWaypoint = NextWaypoint;
                    NextWaypoint = waypoints[Random.Range(0, waypoints.Count)];
                    jump = false;
                }
                else
                {

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
