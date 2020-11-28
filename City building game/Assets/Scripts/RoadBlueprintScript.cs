﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlueprintScript : MonoBehaviour
{
    private Vector3? roadStart = null;
    private Vector3? roadEnd = null;
    public GameObject prefab;
    RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        move();

        if (Input.GetMouseButton(0))
        {
            Debug.Log(roadStart);
        }

        if (Input.GetMouseButtonDown(0) && roadStart == null)
        {
            roadStart = transform.position;
        }
        else if(Input.GetMouseButtonDown(0) && roadEnd == null)
        {
            roadEnd = transform.position;
            buildRoad();
        }

    }
    void move() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 5000.0f, 1))
        {
            transform.position = new Vector3(
                Mathf.Round(hit.point.x / 10.0f) * 10.0f,
                hit.point.y,
                Mathf.Round(hit.point.z / 10.0f) * 10.0f);
        }

    }

     void buildRoad()
     {
        Instantiate(prefab, (Vector3)roadStart, Quaternion.Euler(new Vector3(0,90,0)));
        Destroy(gameObject);

     }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
