using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWayPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    public CarWayPoint getNextWaypoint(CarWayPoint last)
    {
        List<CarWayPoint> c = transform.parent.GetComponent<Road>().GetConnectedWayPoints();
        c.Remove(last);
        System.Random random = new System.Random();
        if (c.Count > 0)
        {
            int r = random.Next(0, c.Count);

            return c[r];

        }
        else
        {
            return last;
        }

    }
}
