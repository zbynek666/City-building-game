using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public WayPoint secondWayPoint;
    public int side;
    private int x;
    private int y;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    public (WayPoint, bool) getNextWaypoint(WayPoint last)
    {
        List<WayPoint> c = transform.parent.GetComponent<Road>().GetConnectedWayPoints();
        c.Remove(last);
        c.Remove(last.secondWayPoint);

        System.Random random = new System.Random();
        if (c.Count > 0)
        {
            int r = random.Next(0, c.Count);
            if (last.side == 1)
            {
                return (c[r], false);

            }
            else
            {
                return (c[r].secondWayPoint, false);

            }





        }
        else
        {
            return (secondWayPoint, true);

        }

    }

    public List<WayPoint> getWaypointsAround()
    {
        return transform.parent.GetComponent<Road>().GetConnectedWayPoints();
    }

}
