using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlueprintScript : MonoBehaviour
{
    private int roadStart = -5000;
    private int roadEnd = -5000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && roadStart != -5000)
        {
            setSrartPoint();
        }
        else if(Input.GetMouseButton(0) && roadEnd != -5000)
        {
            buildRoad();
        }

    }

    private void buildRoad()
    {

    }

    private void setSrartPoint()
    {

    }
}
