using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public int width;
    public int height;
    public int x;
    public int y;
    public void kys()
    {
        Debug.Log(gameObject.GetComponent<Renderer>().bounds.size);
    }

}
