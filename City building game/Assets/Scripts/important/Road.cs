using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : Structure
{
    public Mesh[] curvys = new Mesh[3];
    public Road()
    {
        width = 1;
        height = 1;
    }
    void Start()
    {

        GridManager.Instance.onBuild.AddListener(checkCurvy);
        //curvys[0] = gameObject.GetComponent<MeshFilter>().mesh;
    }
    public void checkCurvy()
    {
        bool[] neighbors = new bool[4] { false, false, false, false };
        int neighbor = 0;

        Structure str = GridManager.Instance.getOnPosition(new Vector2(x + 1, y));

        if (str != null && str.GetType() == typeof(Road))
        {
            neighbors[0] = true;
        }

        str = GridManager.Instance.getOnPosition(new Vector2(x - 1, y));

        if (str != null && str.GetType() == typeof(Road))
        {
            neighbors[1] = true;
        }

        str = GridManager.Instance.getOnPosition(new Vector2(x, y - 1));

        if (str != null && str.GetType() == typeof(Road))
        {
            neighbors[2] = true;
        }

        str = GridManager.Instance.getOnPosition(new Vector2(x, y + 1));

        if (str != null && str.GetType() == typeof(Road))
        {
            neighbors[3] = true;
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
    public void kys()
    {

    }
}
