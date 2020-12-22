using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrid : MonoBehaviour
{
    public GameObject p;
    void Start()
    {
        Grid g = new Grid(150, 150, 10, p);
    }


}
