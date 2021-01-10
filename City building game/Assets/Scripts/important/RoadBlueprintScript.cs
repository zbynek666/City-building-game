using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlueprintScript : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movepoint;
    public GameObject prefab;
    public Vector2 start;

    int isX = 0;//difference on axis X bigger that difference on axis Y

    public RoadBlueprintScript(GameObject p)
    {
        this.prefab = p;
    }
    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.position = hit.point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 5000.0f, 1))
        {
            transform.position = new Vector3(
                Mathf.Round(hit.point.x / GridManager.Instance.gridsize) * GridManager.Instance.gridsize,
                hit.point.y,
                Mathf.Round(hit.point.z / GridManager.Instance.gridsize) * GridManager.Instance.gridsize);

        }

        if (Input.GetMouseButtonDown(0))
        {
            /*
            GameObject g = Instantiate(prefab, transform.position, transform.rotation);
            Structure s = g.GetComponent<Structure>();
            s.x = (int)transform.position.x / GridManager.Instance.gridsize;
            s.y = (int)transform.position.z / GridManager.Instance.gridsize;
            GridManager.Instance.addToPosition(s.x, s.y, s);


            */

            if (start == new Vector2(0.0f, 0.0f))
            {
                start = new Vector2((int)transform.position.x / GridManager.Instance.gridsize, (int)transform.position.z / GridManager.Instance.gridsize);
            }
            else
            {

                Vector2 end = new Vector2((int)transform.position.x / GridManager.Instance.gridsize, (int)transform.position.z / GridManager.Instance.gridsize);

                Debug.Log(Math.Abs(start.x - end.x) + "," + Math.Abs(start.y - end.y) + "");

                if (Math.Abs(start.x - end.x) > Math.Abs(start.y - end.y))
                {
                    isX = 1;


                }


                if (isX == 1)
                {
                    if (start.x > end.x)
                    {
                        placeRoad(-1, 0, (int)(start.x - end.x));

                    }
                    else
                    {
                        placeRoad(1, 0, (int)(end.x - start.x));

                    }

                }
                else
                {

                    if (start.y > end.y)
                    {
                        placeRoad(0, -1, (int)(start.y - end.y));

                    }
                    else
                    {
                        placeRoad(0, 1, (int)(end.y - start.y));

                    }
                }




            }
        }


    }
    private void placeRoad(int plusX, int plusY, int distance)
    {
        bool kys = true;
        Vector2[] v = new Vector2[distance + 1];
        for (int i = 0; i < distance + 1; i++)
        {

            v[i] = (new Vector2((int)start.x + (i * plusX), (int)start.y + (i * plusY)));
            if (GridManager.Instance.getOnPosition((int)v[i].x, (int)v[i].y) != null)
            {
                kys = false;


            }

        }
        if (kys)
        {
            foreach (Vector2 r in v)
            {
                createRoad((int)r.x, (int)r.y);
            }
        }

        Destroy(gameObject);

    }
    public void createRoad(int x, int y)
    {
        GameObject g = Instantiate(prefab, new Vector3(x * GridManager.Instance.gridsize, 0, y * GridManager.Instance.gridsize), Quaternion.Euler(new Vector3(0, 90 - (isX * 90), 0)));
        Structure s = g.GetComponent<Structure>();
        s.x = x;
        s.y = y;
        GridManager.Instance.addToPosition(s.x, s.y, s);
    }
}
