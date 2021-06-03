using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuldingButtonsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blueprint;
    public GameObject p;

    [SerializeField]
    public enum typeOfStructure { road, bulding, zone }


    public typeOfStructure str;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(SpawnBlueprint);
    }

    public void SpawnBlueprint()
    {
        GameObject go = Instantiate(blueprint);

        if (str == typeOfStructure.road)
        {
            go.AddComponent<RoadBlueprintScript>().prefab = p;
        }
        if (str == typeOfStructure.bulding)
        {

            go.AddComponent<Blueprint_script>().prefab = p;

        }
        if (str == typeOfStructure.zone)
        {
            go.AddComponent<zoneBlueprintScript>().prefab = p;
        }

    }

}
