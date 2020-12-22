using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }
    public GameObject p;
    private Grid g;
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
        g = new Grid(150, 150, 10, p, this.transform);
    }
    public void addToPosition(Vector2 x, Vector2 y, Structure ob)
    {
        for (int i = 0; i < 0; i++)
        {
            for (int j = 0; j < 0; j++)
            {
                g.gridArray[i, j] = ob;
            }
        }
    }


}
