using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public int width;
    public int height;
    public int x;
    public int y;

    void Start()
    {
        GameManager.Instance.kys.AddListener(kys);
    }
    public void kys()
    {
        Debug.Log("kys");

    }

}
