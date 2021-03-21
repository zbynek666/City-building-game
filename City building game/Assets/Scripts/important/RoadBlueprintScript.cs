using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlueprintScript : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movepoint;
    public GameObject prefab;
    private Vector2 start = new Vector2(-1, -1);
    private Vector2 gridPosition;
    private Vector2 lastgridPosition = new Vector2(-1, -1);
    private List<GameObject> bluePrints;
    private int finalDistance;
    private int finalRot;

    public RoadBlueprintScript(GameObject p)
    {
        this.prefab = p;
    }
    public void Start()
    {
        start = new Vector2(-1, -1);
        bluePrints = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //placing road
        if (Input.GetMouseButtonDown(0))
        {
            if (start == new Vector2(-1, -1) && GridManager.Instance.getOnPosition(gridPosition) == null)
            {
                start = gridPosition;
            }
            else if (GridManager.Instance.getOnPosition(gridPosition) == null)
            {
                placeRoad(finalDistance);
                for (int i = 0; i < bluePrints.Count; i++)
                {
                    Destroy(bluePrints[i]);

                }
                bluePrints.Clear();
                Destroy(gameObject);
            }
            else
            {
                //someting is on position
            }
        }

        //visualizatin one in hand
        if (start == new Vector2(-1, -1))
        {
            if (Physics.Raycast(ray, out hit, 5000.0f, 1))
            {

                gridPosition = GridManager.Instance.getPositionOnGrid(new Vector2(hit.point.x, hit.point.z));
                if (gridPosition.x != -1)
                {
                    transform.position = new Vector3(gridPosition.x * GridManager.Instance.gridsize, 0, gridPosition.y * GridManager.Instance.gridsize);

                }

            }
        }
        else
        {

            if (Physics.Raycast(ray, out hit, 5000.0f, 1))
            {

                gridPosition = GridManager.Instance.getPositionOnGrid(new Vector2(hit.point.x, hit.point.z));


                if (gridPosition != lastgridPosition)
                {
                    int differenceX = Math.Abs(Math.Abs((int)start.x) - Math.Abs((int)gridPosition.x));
                    int differenceY = Math.Abs(Math.Abs((int)start.y) - Math.Abs((int)gridPosition.y));


                    if (differenceX > differenceY)
                    {
                        if (start.x < gridPosition.x)
                        {

                            finalDistance = Math.Abs((int)start.x - (int)gridPosition.x);
                            finalRot = 0;
                            blueprintVisualization(finalDistance, 0);
                            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

                        }
                        else
                        {
                            finalDistance = Math.Abs((int)gridPosition.x - (int)start.x);
                            finalRot = 2;
                            blueprintVisualization(finalDistance, 2);
                            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                        }

                    }
                    else
                    {
                        if (start.y < gridPosition.y)
                        {
                            finalDistance = Math.Abs((int)start.y - (int)gridPosition.y);
                            blueprintVisualization(finalDistance, 1);
                            this.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                            finalRot = 1;
                        }
                        else
                        {
                            finalDistance = Math.Abs((int)gridPosition.y - (int)start.y);
                            finalRot = 3;
                            blueprintVisualization(finalDistance, 3);
                            this.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));



                        }

                    }

                    lastgridPosition = gridPosition;

                }



            }
        }



    }
    private void blueprintVisualization(int size, int direction)
    {

        int plusX = 0;
        int plusY = 0;
        int rot = 0;
        //TODO strany
        if (direction == 0)
        {
            plusX = GridManager.Instance.gridsize;

        }
        if (direction == 1)
        {
            plusY = GridManager.Instance.gridsize;
            rot = 90;

        }
        if (direction == 2)
        {
            plusX = -GridManager.Instance.gridsize;

        }
        if (direction == 3)
        {
            plusY = -GridManager.Instance.gridsize;
            rot = 90;

        }

        for (int i = 0; i < bluePrints.Count; i++)
        {
            Destroy(bluePrints[i]);
        }
        bluePrints.Clear();
        Vector2 s = GridManager.Instance.getRealPosition(start);

        for (int i = 0; i < size + 1; i++)
        {

            GameObject g = Instantiate(gameObject, new Vector3(s.x + (i * plusX), 0, s.y + (i * plusY)), Quaternion.Euler(new Vector3(0, rot, 0)));
            Destroy(g.GetComponent<RoadBlueprintScript>());
            bluePrints.Add(g);
        }

    }

    private void placeRoad(int distance)
    {
        int plusX = 0;
        int plusY = 0;
        if (finalRot == 0)
        {
            plusX = 1;
        }
        else if (finalRot == 1)
        {
            plusY = 1;
        }
        else if (finalRot == 2)
        {
            plusX = -1;
        }
        else if (finalRot == 3)
        {
            plusY = -1;
        }
        //check if is in way


        bool kys = true;
        Vector2[] v = new Vector2[distance + 1];
        for (int i = 0; i < distance + 1; i++)
        {

            v[i] = (new Vector2((int)start.x + (i * plusX), (int)start.y + (i * plusY)));
            if (GridManager.Instance.getOnPosition(new Vector2((int)v[i].x, (int)v[i].y)) != null)
            {
                kys = false;
            }

        }

        //placing road 
        if (kys && GlobalVariables.money >= v.Length * 100)
        {
            GlobalVariables.money -= v.Length * 100;
            foreach (Vector2 r in v)
            {

                createRoad((int)r.x, (int)r.y);
            }
            for (int i = 0; i < bluePrints.Count; i++)
            {
                Destroy(bluePrints[i]);
            }
            bluePrints.Clear();
        }

        GridManager.Instance.onBuild.Invoke();

    }
    private void createRoad(int x, int y)
    {
        int rot = 0;
        if (finalRot == 1 || finalRot == 3)
        {
            rot = 1;
        }
        GameObject g = Instantiate(prefab, new Vector3(x * GridManager.Instance.gridsize, 0,
            y * GridManager.Instance.gridsize), Quaternion.Euler(new Vector3(0, (rot * 90), 0)));
        //smoke
        Instantiate(GameManager.Instance.placeSmoke, new Vector3(x * GridManager.Instance.gridsize, 0,
            y * GridManager.Instance.gridsize), new Quaternion());

        Structure s = g.GetComponent<Structure>();
        s.x = x;
        s.y = y;
        GridManager.Instance.addToPosition(s.x, s.y, s);
    }
}
