using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }
    public GameObject linePrefub;
    public Grid g;
    public int gridsize = 10;
    public int width = 150;
    public int height = 150;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        g = new Grid(width, height, gridsize, linePrefub, this.transform);
    }
    public void addToPosition(int x, int y, Structure ob)
    {
        for (int i = 0; i < 1; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                g.gridArray[x, y] = ob;
            }
        }

    }
    public Structure getOnPosition(Vector2 pos)
    {
        return g.AtPosition((int)pos.x, (int)pos.y);
    }
    public Vector2 getPositionOnGrid(RaycastHit hit)
    {

        Vector2 position = new Vector2(Mathf.Round(hit.point.x / gridsize), Mathf.Round(hit.point.z / gridsize));
        if (position.x < 0 || position.y < 0 || position.x > height || position.y > width)
        {
            return new Vector2(-1, -1);
        }
        return position;

    }
    public Vector2 getRealPosition(Vector2 pos)
    {
        Vector2 position = new Vector2(pos.x * gridsize, pos.y * gridsize);
        return position;
    }

    public void debugLog()
    {
        string s = "";
        for (int i = 0; i < g.gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < g.gridArray.GetLength(1); j++)
            {
                if (g.gridArray[i, j] != null)
                {
                    s += "X";
                }
                else
                {
                    s += "  ";
                }

            }
            s += System.Environment.NewLine;
        }
        Debug.Log(s);
    }


}
