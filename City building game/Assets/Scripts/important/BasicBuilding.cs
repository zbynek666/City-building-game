using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicBuilding : Building
{
    public int maxPopulation = 4;
    public int population = 0;

    public int happines = 100;

    public int level = 1;
    public GameObject fire;

    public GameObject policeCar;
    public GameObject Ambulance;



    public GameObject[] level1Meshs;

    public GameObject[] level2Meshs;
    public GameObject[] level3Meshs;

    protected int maxHappinesBybuilding = 30;

    protected int HappinesBybuilding = 0;
    protected int globalHappins = 0;

    protected int happisesByTaxes = 0;

    protected int maxHappisesByTaxes = 30;














    // Start is called before the first frame update
    protected void Start()
    {

        int rand = Random.Range(0, level1Meshs.Length);
        GetComponent<MeshFilter>().mesh = level1Meshs[rand].GetComponent<MeshFilter>().sharedMesh;
        GetComponent<MeshRenderer>().materials = level1Meshs[rand].GetComponent<MeshRenderer>().sharedMaterials;
        base.Start();

        rotateTowardRoad();
    }

    protected void TryLevelUp()
    {
        if (happines == 100)
        {
            Debug.Log("level Up");
            if (level == 1)
            {
                LevelUp(2, new Structure[] { });

            }
            else if (level == 2)
            {
                int[,] sracka = new int[,] { { 1, 1, 1, 0, 0, 1 }, { -1, 1, 0, 1, 0, -1 }, { 0, -1, -1, -1, -1, 0 }, { 0, 1, -1, 0, -1, 1 } };
                for (int i = 0; i < 4; i++)
                {
                    Structure s1 = GridManager.Instance.getOnPosition(new Vector2(x + sracka[i, 0], y + sracka[i, 1]));
                    Structure s2 = GridManager.Instance.getOnPosition(new Vector2(x + sracka[i, 2], y + sracka[i, 3]));
                    Structure s3 = GridManager.Instance.getOnPosition(new Vector2(x + sracka[i, 4], y + sracka[i, 5]));


                    if ((s1 == null || ((s1 is BasicBuilding && ((BasicBuilding)s1).happines == 100 && ((BasicBuilding)s1).level == level))) &&
                        (s2 == null || ((s2 is BasicBuilding && ((BasicBuilding)s2).happines == 100 && ((BasicBuilding)s2).level == level))) &&
                        (s3 == null || ((s3 is BasicBuilding && ((BasicBuilding)s3).happines == 100 && ((BasicBuilding)s3).level == level))))
                    {
                        LevelUp(3, new Structure[] { s1, s2, s3 });
                        break;
                    }
                }
            }




        }

    }
    protected void LevelUp(int l, Structure[] structures)
    {
        if (l == 2)
        {
            int rand = Random.Range(0, level2Meshs.Length);

            GetComponent<MeshFilter>().mesh = level2Meshs[rand].GetComponent<MeshFilter>().sharedMesh;
            GetComponent<MeshRenderer>().materials = level2Meshs[rand].GetComponent<MeshRenderer>().sharedMaterials;


        }
        else if (l == 3 && false)
        {
            foreach (Structure s in structures)
            {
                if (s != null)
                {
                    s.Destroy();

                }
            }
            int rand = Random.Range(0, level3Meshs.Length);

            GetComponent<MeshFilter>().mesh = level3Meshs[rand].GetComponent<MeshFilter>().sharedMesh;
            GetComponent<MeshRenderer>().materials = level3Meshs[rand].GetComponent<MeshRenderer>().sharedMaterials;

        }


        for (int i = 0; i < GetComponent<MeshRenderer>().sharedMaterials.Length; i++)
        {
            if (i < originalColors.Count)
            {
                originalColors[i] = GetComponent<MeshRenderer>().sharedMaterials[i].color;

            }
            else
            {
                originalColors.Add(GetComponent<MeshRenderer>().sharedMaterials[i].color);
            }
        }









        level = level + 1;

    }
    public string[] info()
    {

        return new string[] { hasRoad + "", hasMainCon + "", hasPower + "", hasWater + "", hasPolice + "", hasFire + "", hasHealtcare + "", population + "", maxPopulation + "", happines + "" };
    }




    protected override void onDay()
    {
        base.onDay();
        TryLevelUp();
        happisesByTaxes = (int)((0.15f - GameManager.Instance.getTaxes()[0]) / 0.01f);

        if (happisesByTaxes > maxHappisesByTaxes)
        {
            happisesByTaxes = maxHappisesByTaxes;
        }
        else if (happisesByTaxes < -maxHappisesByTaxes)
        {
            happisesByTaxes = -maxHappisesByTaxes;
        }

        calculateHappines();

    }

    // Update is called once per frame
    public void EventHappened(Service.typeOfService serv)
    {
        if (serv == Service.typeOfService.Fire)
        {
            Instantiate(fire, gameObject.transform);
            ChangeToDestroyedBuildings();
        }


        else if (serv == Service.typeOfService.Healthcare)
        {
            population--;
            if (population < 1)
            {
                ChangeToDestroyedBuildings();

            }
            SpawnAmbulance();
        }
        else if (serv == Service.typeOfService.Police)
        {
            SpawnPoliceCars();
            happines -= 10;
            if (happines < 1)
            {
                ChangeToDestroyedBuildings();

            }
        }

    }

    protected void ChangeToDestroyedBuildings()
    {

        for (int i = 0; i < gameObject.GetComponent<Renderer>().materials.Length; i++)
        {
            Color c = gameObject.GetComponent<Renderer>().materials[i].color;
            gameObject.GetComponent<Renderer>().materials[i].color = new Color(c.r - 0.4f, c.g - 0.4f, c.b - 0.4f);
        }
        for (int i = 0; i < gameObject.GetComponent<Renderer>().materials.Length; i++)
        {
            Color c = gameObject.GetComponent<Renderer>().materials[i].color;
            originalColors[i] = gameObject.GetComponent<Renderer>().materials[i].color;
        }
        gameObject.AddComponent<Destroyed_Building>();
        Destroy(this);
    }

    protected void SpawnPoliceCars()
    {
        foreach (Structure s in getNeighbors())
        {
            if (s is Road)
            {

                GameObject g = new GameObject();
                g.transform.parent = s.transform;
                g.transform.localPosition = new Vector3(0, 0, 0);


                GameObject p = Instantiate(policeCar, g.transform);
                p.transform.localPosition = new Vector3(3, 0, 3);
                p.transform.localRotation = new Quaternion(0, 0.3f, 0, 0.9f);
                Object.Destroy(p, 10.0f);

                p = Instantiate(policeCar, g.transform);
                p.transform.localPosition = new Vector3(3, 0, -3);
                p.transform.localRotation = new Quaternion(0, 0.8f, 0, 0.6f);
                Object.Destroy(p, 10.0f);

            }
        }
    }

    protected void SpawnAmbulance()
    {
        foreach (Structure s in getNeighbors())
        {
            if (s is Road)
            {

                GameObject g = new GameObject();
                g.transform.parent = s.transform;
                g.transform.localPosition = new Vector3(0, 0, 0);


                GameObject p = Instantiate(Ambulance, g.transform);
                p.transform.localPosition = new Vector3(3, 2, 3);
                p.transform.localRotation = new Quaternion(0, 0.3f, 0, 0.9f);
                Object.Destroy(p, 10.0f);



            }
        }
    }

    public void rotateTowardRoad()
    {
        for (int i = 0; i < 4; i++)
        {
            if (getNeighbors()[i] is Road)
            {
                if (i == 0)
                {
                    transform.rotation = Quaternion.Euler(0, 90, 0);

                }
                else
                    if (i == 1)
                {
                    transform.rotation = Quaternion.Euler(0, 270, 0);

                }
                else
                    if (i == 2)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);

                }
                else if (i == 3)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);

                }
            }
        }
    }

    public void addHappines(int h)
    {

        HappinesBybuilding += h;
        if (HappinesBybuilding > maxHappinesBybuilding)
        {
            HappinesBybuilding = maxHappinesBybuilding;
        }

    }

    public abstract void calculateHappines();


}





