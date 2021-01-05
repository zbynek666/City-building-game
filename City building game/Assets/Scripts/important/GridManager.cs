using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }
    public GameObject linePrefub;
    public Grid g;
    public int gridsize = 10;
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
        g = new Grid(150, 150, gridsize, linePrefub, this.transform);
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
        House h = new House();

    }
    public Structure getOnPosition(int x, int y)
    {
        return g.AtPosition(x, y);
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
