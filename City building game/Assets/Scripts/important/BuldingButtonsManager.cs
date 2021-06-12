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


        if (str == typeOfStructure.road)
        {
            GameObject go = Instantiate(blueprint);


            go.AddComponent<RoadBlueprintScript>().prefab = p;
        }
        if (str == typeOfStructure.bulding)
        {
            GameObject go = Instantiate(p);
            Destroy(go.GetComponent<Structure>());

            go.AddComponent<Blueprint_script>().prefab = p;

            if (go.GetComponent<Renderer>() != null)
            {
                foreach (Material m in go.GetComponent<Renderer>().materials)
                {
                    Color c = m.color;


                    m.color = new Color(c.r, c.g, c.b, 0.2f);
                }
            }
            foreach (Transform kys in go.transform)
            {
                if (kys.GetComponent<Renderer>() != null)
                {

                    foreach (Material m in kys.GetComponent<Renderer>().materials)
                    {
                        Color c = m.color;

                        m.color = new Color(c.r, c.g, c.b, 0.2f);
                    }
                }
            }

        }
        if (str == typeOfStructure.zone)
        {
            GameObject go = Instantiate(p);
            Destroy(go.GetComponent<Zone>());

            go.AddComponent<zoneBlueprintScript>().prefab = p;

            foreach (Material m in go.GetComponent<Renderer>().materials)
            {
                Color c = m.color;

                m.color = new Color(c.r, c.g, c.b, 0.2f);
            }



        }

    }

}
