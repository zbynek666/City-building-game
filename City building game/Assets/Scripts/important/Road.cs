using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : Structure
{
    public Mesh[] curvys = new Mesh[3];

    public bool[] connections = new bool[3];

    public CarWayPoint carWayPoint;


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







        //curvys[0] = gameObject.GetComponent<MeshFilter>().mesh;
        //GameObject g = Instantiate(new emp, transform.position, transform.rotation);


        checkCurvy();

        createCarWayPoint();

    }

    private void createCarWayPoint()
    {
        GameObject g = new GameObject("WayPoint");
        g.transform.parent = gameObject.transform;
        g.transform.localPosition = new Vector3();
        carWayPoint = g.AddComponent<CarWayPoint>();

    }

    private void check()
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
        if (neighbor < 3)
        {


            if (neighbors[0] && neighbors[2])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[1];
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            if (neighbors[0] && neighbors[3])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[1];
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            if (neighbors[0] && neighbors[1])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[0];
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

            }

            if (neighbors[1] && neighbors[2])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[1];
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            if (neighbors[1] && neighbors[3])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[1];
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            if (neighbors[2] && neighbors[3])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[0];
                gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);

            }


        }
        else if (neighbor == 3)
        {

            if (neighbors[0] && neighbors[1] && neighbors[2])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[2];
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);


            }
            if (neighbors[0] && neighbors[1] && neighbors[3])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[2];
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);


            }
            if (neighbors[0] && neighbors[3] && neighbors[2])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[2];
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);


            }
            if (neighbors[3] && neighbors[1] && neighbors[2])
            {
                gameObject.GetComponent<MeshFilter>().mesh = curvys[2];
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);


            }

        }
        else
        {
            gameObject.GetComponent<MeshFilter>().mesh = curvys[3];

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
        Debug.Log("road connect" + conns[2]);


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

    public List<CarWayPoint> GetConnectedWayPoints()
    {
        Structure[] nei = getNeighbors();
        List<CarWayPoint> wayPoints = new List<CarWayPoint>();
        foreach (Structure s in nei)
        {

            if (s is Road)
            {
                wayPoints.Add(((Road)s).carWayPoint);

            }
        }

        return wayPoints;
    }

}
