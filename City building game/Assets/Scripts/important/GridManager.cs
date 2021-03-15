using System;
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

        //nastavit do cyklu velikost budovy
        for (int i = 0; i < 1; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                if (g.gridArray[x, y] != null)
                {
                    Destroy(g.gridArray[x, y].gameObject);
                    Debug.Log("destroy");

                }
                g.gridArray[x, y] = ob;
            }
        }

    }
    public Structure getOnPosition(Vector2 pos)
    {
        Structure str = g.AtPosition((int)pos.x, (int)pos.y);
        if (str is Zone)
        {
            return str;
        }
        return str;

    }
    public Vector2 getPositionOnGrid(Vector2 hit)
    {

        Vector2 position = new Vector2(Mathf.Round(hit.x / gridsize), Mathf.Round(hit.y / gridsize));
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
        //Debug.Log(s);
    }
    public bool isNearRoad(Vector2 position)
    {
        if (getOnPosition(new Vector2(position.x + 1, position.y)) is Road || getOnPosition(new Vector2(position.x - 1, position.y)) is Road ||
            getOnPosition(new Vector2(position.x, position.y + 1)) is Road || getOnPosition(new Vector2(position.x, position.y - 1)) is Road)
        {
            return true;
        }
        return false;
    }

    public Structure canPlaceZone(Vector2 pos, Type type)
    {
        Structure str = g.AtPosition((int)pos.x, (int)pos.y);
        if (str != null && str.GetType() == type)
        {
            return str;
        }
        /*
         if(is zone )
        {
        return null;
        }
         */
        return str;

    }
    public List<Structure> getTypeOfObject<T>()
    {

        if (typeof(T) == typeof(Residenc))
        {

            List<Structure> r = new List<Structure>();
            for (int i = 0; i < g.gridArray.GetLength(0); i++)
            {
                for (int j = 0; j < g.gridArray.GetLength(1); j++)
                {


                    if (g.AtPosition(i, j) != null && g.AtPosition(i, j).GetType() == typeof(Residenc))
                    {
                        bool isIn = false;
                        for (int k = 0; k < r.Count; k++)
                        {
                            if (r[k] == g.AtPosition(i, j))
                            {
                                isIn = true;
                            }
                        }
                        if (!isIn)
                        {
                            r.Add(g.AtPosition(i, j));

                        }

                    }


                }
            }
            return r;
        }
        return null;
    }


}
