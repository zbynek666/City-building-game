using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuldingButtonsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blueprint;
    public GameObject p;
    public bool isRoad;

    public void SpawnBlueprint()
    {
        GameObject go = Instantiate(blueprint);

        if (isRoad)
        {
            go.AddComponent<RoadBlueprintScript>().prefab = p;
        }
        else
        {

            go.AddComponent<Blueprint_script>().prefab = p;

        }

    }

}
