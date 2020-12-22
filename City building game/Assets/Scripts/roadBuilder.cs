using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadBuilder : MonoBehaviour
{
    public RoadBlueprintScript roadBlueprint;
    RoadBlueprintScript blueprint;
    Vector3 roadStart;
    bool planningPhase = false;
    List<RoadBlueprintScript> blueprintsArray = new List<RoadBlueprintScript>();
    RaycastHit hit;
    int angle = 0;
    int length = 0;
    void Start()
    {

        blueprint = Instantiate(roadBlueprint, roadBlueprint.transform.position, roadBlueprint.transform.rotation);
    }

    void Update()
    {
        if (blueprint != null)
        {
            blueprint.move();
            if (Input.GetMouseButtonDown(0))
            {
                roadStart = blueprint.transform.position;
                blueprint.destroyGameObject();
                planningPhase = true;
            }
        }
        if (Input.GetMouseButtonDown(0) && planningPhase)
        {
            finishRoad(length, angle);
        }



        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 5000.0f, 1))
        {
            if (planningPhase)
            {
                angle = AngleBetweenTwoPoints(roadStart, hit.point);
                length = CalculateLenght(roadStart, hit.point);
                if (angle != blueprintsArray[0].transform.rotation.y || blueprintsArray.Count != length)
                {
                    updateblueprintsArray();
                }

            }
        }


    }

    private void finishRoad(int length, int angle)
    {

    }

    void updateblueprintsArray()
    {

    }
    int AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {

        return (int)(Mathf.Round((Mathf.Atan2(a.z - b.z, a.x - b.x) * Mathf.Rad2Deg) / 90)) * 90;

    }
    int CalculateLenght(Vector3 a, Vector3 b)
    {

        return 0;
    }

}
