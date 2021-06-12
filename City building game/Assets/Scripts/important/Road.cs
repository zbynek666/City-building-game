using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : Structure
{
    protected Mesh[] curvys = new Mesh[5];

    public GameObject[] roads = new GameObject[5];


    public bool[] connections = new bool[3];

    public WayPoint carWayPoint1;
    public WayPoint carWayPoint2;

    public WayPoint PeopleWayPoint1;
    public WayPoint PeopleWayPoint2;

    bool isAfterStart = false;



    public Road()
    {
        width = 1;
        height = 1;
        for (int i = 0; i < connections.Length; i++)
        {
            connections[i] = false;
        }

        connections[0] = isPlaceByDefault;



    }
    void Awake()
    {
        GridManager.Instance.beforeBuild.AddListener(disconnect);

        GridManager.Instance.onBuild.AddListener(check);
    }

    void Start()
    {
        base.Start();
        foreach (GameObject r in roads)
        {
            curvys[Array.IndexOf(roads, r)] = r.GetComponent<MeshFilter>().sharedMesh;
        }
        //GetComponent<MeshFilter>().mesh = curvys[3];








        //curvys[0] = gameObject.GetComponent<MeshFilter>().mesh;
        //GameObject g = Instantiate(new emp, transform.position, transform.rotation);

        if (!isPlaceByDefault)
        {
            checkCurvy();

        }

        createCarWayPoint();
        isAfterStart = true;
    }

    private void createCarWayPoint()
    {
        //creation car waypoints
        GameObject g1 = new GameObject("CarWayPoint1");
        g1.transform.parent = gameObject.transform;
        g1.transform.localPosition = new Vector3(0, 0, 0);
        carWayPoint1 = g1.AddComponent<WayPoint>();
        carWayPoint1.side = 1;



        //creation waypoints for peoples 
        /*
        g1 = new GameObject("CarWayPoint1");
        g1.transform.parent = gameObject.transform;
        g1.transform.localPosition = new Vector3(0, 0, -2);
        carWayPoint1 = g1.AddComponent<WayPoint>();
        carWayPoint1.side = 1;

        g2 = new GameObject("CarWayPoint2");
        g2.transform.parent = gameObject.transform;
        g2.transform.localPosition = new Vector3(0, 0, 2);
        carWayPoint2 = g2.AddComponent<WayPoint>();
        carWayPoint2.side = 2;

        PeopleWayPoint2.secondWayPoint = carWayPoint1;
        PeopleWayPoint1.secondWayPoint = carWayPoint2;
        */

    }


    private void check()
    {

        if (isAfterStart)
        {
            checkCurvy();

            if (isPlaceByDefault)
            {
                connections[0] = true;

                foreach (Structure s in getNeighbors())
                {

                    if (s != null && s.GetType() == typeof(Road))
                    {
                        Road r = (Road)s;
                        bool same = true;
                        for (int i = 0; i < connections.Length; i++)
                        {
                            if (connections[i] == true && r.connections[i] == false)
                            {
                                same = false;
                            }
                        }
                        if (!same)
                        {
                            r.connect(connections);
                        }
                    }
                }
            }
        }






    }

    private void checkCurvy()
    {



        bool[] neighbors = new bool[4] { false, false, false, false };
        int neighbor = 0;
        Structure[] str = getNeighbors();
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != null && str[i].GetType() == typeof(Road))
            {
                neighbors[i] = true;
            }
        }



        foreach (bool s in neighbors)
        {
            if (s)
            {
                neighbor++;

            }
        }
        GetComponent<MeshRenderer>().materials = roads[1].GetComponent<MeshRenderer>().sharedMaterials;

        if (neighbor == 1)
        {
            if (neighbors[0])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[4];
                gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);


            }
            if (neighbors[1])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[4];
                gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);


            }
            if (neighbors[2])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[4];
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);


            }
            if (neighbors[3])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[4];
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);


            }
        }
        else if (neighbor == 2)
        {


            if (neighbors[0] && neighbors[1])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[0];
                gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (neighbors[2] && neighbors[3])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[0];
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            else if (neighbors[0] && neighbors[2])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[1];
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (neighbors[0] && neighbors[3])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[1];
                gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (neighbors[1] && neighbors[2])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[1];
                gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
            }
            else if (neighbors[1] && neighbors[3])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[1];
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }




        }
        else if (neighbor == 3)
        {
            GetComponent<MeshRenderer>().materials = roads[2].GetComponent<MeshRenderer>().sharedMaterials;

            if (neighbors[0] && neighbors[1] && neighbors[2])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[2];
                gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);


            }
            if (neighbors[0] && neighbors[1] && neighbors[3])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[2];
                gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);


            }
            if (neighbors[0] && neighbors[3] && neighbors[2])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[2];
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);//


            }
            if (neighbors[3] && neighbors[1] && neighbors[2])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[2];
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);//


            }


        }
        else
        {
            gameObject.GetComponent<MeshFilter>().mesh = curvys[3];
            GetComponent<MeshRenderer>().materials = roads[3].GetComponent<MeshRenderer>().sharedMaterials;


        }




    }
    public void connect(bool[] conns)
    {
        for (int i = 0; i < connections.Length; i++)
        {
            connections[i] = conns[i];
        }
        changeIcon(null);
        foreach (Structure s in getNeighbors())
        {

            if (s != null && s.GetType() == typeof(Road))
            {
                Road r = (Road)s;
                bool same = true;
                for (int i = 0; i < connections.Length; i++)
                {
                    if (connections[i] == true && r.connections[i] == false)
                    {
                        same = false;
                    }
                }
                if (!same)
                {
                    r.connect(connections);
                }
            }
        }
    }
    public void disconnect()
    {
        if (!isPlaceByDefault)
        {
            for (int i = 0; i < connections.Length; i++)
            {
                connections[i] = false;
            }

            Texture2D tex = new Texture2D(100, 100);

            Sprite mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            changeIcon(mySprite);

        }

    }

    public List<WayPoint> GetConnectedWayPoints()
    {
        Structure[] nei = getNeighbors();
        List<WayPoint> wayPoints = new List<WayPoint>();
        foreach (Structure s in nei)
        {

            if (s is Road)
            {
                wayPoints.Add(((Road)s).carWayPoint1);


            }
        }

        return wayPoints;
    }



}
