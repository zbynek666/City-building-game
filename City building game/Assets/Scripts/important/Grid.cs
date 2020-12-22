using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Grid
{
    private int width;
    private int height;
    private int cellSize;
    private GameObject[,] gridArray;
    private GameObject line;

    public Grid(int w, int h, int cs, GameObject l)
    {
        this.width = w;
        this.height = h;
        this.cellSize = cs;
        this.line = l;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject.Instantiate(l, new Vector3(getWorldPosition(i, j).x, 0, getWorldPosition(i, j).y), new Quaternion());
                GameObject.Instantiate(l, new Vector3(getWorldPosition(i, j).x, 0, getWorldPosition(i, j).y), Quaternion.Euler(new Vector3(0, 90, 0)));

            }
        }

    }
    public GameObject AtPosition(int x, int y)
    {
        return null;
    }
    public Vector2 getWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }






}
