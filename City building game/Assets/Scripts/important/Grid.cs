using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Grid
{
    private int width;
    private int height;
    private int cellSize;
    public Structure[,] gridArray;
    private GameObject line;
    List<GameObject> kys = new List<GameObject>();

    GameObject gridPlane;

    public Grid(int w, int h, int cs, GameObject l, Transform parent, GameObject gp)
    {
        this.width = w;
        this.height = h;
        this.cellSize = cs;
        this.line = l;

        gridArray = new Structure[width, height];

        gridPlane = gp;
        /*
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (i == 0)
                {
                    var NewLine = GameObject.Instantiate(l, new Vector3(getWorldPosition(i, j).x -
  (cellSize / 2), 0, getWorldPosition(i, j).y - (cellSize / 2)), Quaternion.Euler(new Vector3(0, 90, 0)));
                    NewLine.transform.localScale = new Vector3(0.03f, 1, width);

                    NewLine.transform.parent = parent;



                }
                if (j == 0)
                {
                    var NewLine = GameObject.Instantiate(l, new Vector3(getWorldPosition(i, j).x -
    (cellSize / 2), 0, getWorldPosition(i, j).y - (cellSize / 2)), new Quaternion());
                    NewLine.transform.localScale = new Vector3(0.03f, 1, height);
                    NewLine.transform.parent = parent;

                }
            }
        }*/

        CreateVisualGrid();

        /*for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var NewLine = GameObject.Instantiate(line, new Vector3(i * cellSize + (cellSize / 2), 0, j * cellSize), Quaternion.Euler(new Vector3(0, 0, 0)));

            }
        }*/

    }

    private void CreateVisualGrid()
    {
        GameObject grid = GameObject.CreatePrimitive(PrimitiveType.Plane);
        grid.name = "Grid";
        grid.transform.localScale = new Vector3(10, 10, 10);
        grid.transform.position = new Vector3(-5, 0, -5);

        int GridSize = width;

        /*
        float thick = 0.02f;

        for (int i = 0; i < width + 2; i++)
        {
            var NewLine = GameObject.Instantiate(line, new Vector3(0 + (i * cellSize) - cellSize / 2, 0, -cellSize), Quaternion.Euler(new Vector3(0, 0, 0)));
            NewLine.transform.localScale = new Vector3(thick, 1, height + 1);

            NewLine.transform.parent = grid.transform;

        }
        for (int i = 0; i < height + 2; i++)
        {
            var NewLine = GameObject.Instantiate(line, new Vector3(-cellSize, 0, 0 + (i * cellSize) - cellSize / 2), Quaternion.Euler(new Vector3(0, 90, 0)));
            NewLine.transform.localScale = new Vector3(thick, 1, width + 1);

            NewLine.transform.parent = grid.transform;

        }*/


        MeshFilter filter = grid.GetComponent<MeshFilter>();
        var mesh = new Mesh();
        var verticies = new List<Vector3>();

        var indicies = new List<int>();

        for (int i = 0; i < GridSize + 1; i++)
        {
            verticies.Add(new Vector3(i, 0, 0));
            verticies.Add(new Vector3(i, 0, GridSize));

            indicies.Add(4 * i + 0);
            indicies.Add(4 * i + 1);

            verticies.Add(new Vector3(0, 0, i));
            verticies.Add(new Vector3(GridSize, 0, i));

            indicies.Add(4 * i + 2);
            indicies.Add(4 * i + 3);
        }

        mesh.vertices = verticies.ToArray();
        mesh.SetIndices(indicies.ToArray(), MeshTopology.Lines, 0);
        filter.mesh = mesh;

        MeshRenderer meshRenderer = grid.GetComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Sprites/Default"));
        meshRenderer.material.color = new Color(200 / 255f, 200 / 255f, 200 / 255f, 50 / 255f); ;

    }

    public Structure AtPosition(int x, int y)
    {
        if (x < 0 || x > width || y < 0 || y > width)
        {
            return null;
        }
        return gridArray[x, y];
    }
    public Vector3 getWorldPosition(int x, int y)
    {
        return new Vector3(x, 0, y) * cellSize;
    }






}
