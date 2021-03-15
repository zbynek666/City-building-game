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

    public Grid(int w, int h, int cs, GameObject l, Transform parent)
    {
        this.width = w;
        this.height = h;
        this.cellSize = cs;
        this.line = l;

        gridArray = new Structure[width, height];

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
        }

    }
    public Structure AtPosition(int x, int y)
    {
        return gridArray[x, y];
    }
    public Vector2 getWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }






}
