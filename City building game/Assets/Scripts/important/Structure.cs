using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public int width;
    public int height;
    public int x;
    public int y;

    public bool isPlaceByDefault = false;

    void Start()
    {
        Vector2 v = GridManager.Instance.getPositionOnGrid(new Vector2(transform.position.x, transform.position.z));
        x = (int)v.x;
        y = (int)v.y;
    }
    public void kys()
    {
        Debug.Log("kys");

    }

}
