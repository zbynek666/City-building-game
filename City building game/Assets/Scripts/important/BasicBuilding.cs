using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicBuilding : Building
{
    public int maxPopulation = 4;
    public int population = 4;

    public int happines = 100;

    public int level = 1;
    public GameObject fire;








    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
    }

    protected void TryLevelUp()
    {
        if (happines == 100)
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
                    LevelUp(new Structure[] { s1, s2, s3 });
                    break;
                }
            }


        }

    }
    protected void LevelUp(Structure[] structures)
    {
        foreach (Structure s in structures)
        {
            if (s != null)
            {
                s.Destroy();

            }
        }
        happines = 50;
        level = level + 1;
    }
    public bool[] info()
    {
        EventHappened(Service.typeOfService.Fire);

        return new bool[] { hasRoad, hasMainCon, hasPower, hasWater, hasPolice, hasFire, hasHealtcare };
    }




    protected override void onDay()
    {
        base.onDay();
        TryLevelUp();
    }

    // Update is called once per frame
    public void EventHappened(Service.typeOfService serv)
    {
        if (serv == Service.typeOfService.Fire)
        {
            Instantiate(fire, gameObject.transform);
            for (int i = 0; i < gameObject.GetComponent<Renderer>().materials.Length; i++)
            {
                Color c = gameObject.GetComponent<Renderer>().materials[i].color;
                gameObject.GetComponent<Renderer>().materials[i].color = new Color(c.r - 0.4f, c.g - 0.4f, c.b - 0.4f);
            }
        }
    }




}
