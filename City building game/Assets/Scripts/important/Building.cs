using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : Structure
{

    // Start is called before the first frame update
    public bool requireRoad = false;
    public bool requireMainCon = false;
    public bool requirePower = false;
    public bool requireWater = false;

    public int PowerConsumption = 4;
    public int WaterConsumption = 4;
    public int GarbageDisposalConsumption = 4;
    public int SewageConsumption = 4;




    public bool active = true;

    protected bool hasRoad;
    protected bool hasMainCon;
    protected bool hasPower;
    protected bool hasWater;
    protected bool hasPolice;
    protected bool hasFire;
    protected bool hasHealtcare;




    protected void Start()
    {
        base.Start();

        gameObject.AddComponent<BoxCollider>();
        GridManager.Instance.beforeBuild.AddListener(clear);
        GridManager.Instance.afterRoadConnections.AddListener(set);
        GameManager.Instance.onDay.AddListener(onDay);
        GameManager.Instance.onMonths.AddListener(OnMonths);

        set();

    }

    // Update is called once per frame



    protected virtual void clear()
    {
        hasRoad = false;
        hasMainCon = false;
        hasPower = false;
        hasWater = false;

        hasPolice = false;
        hasFire = false;
        hasHealtcare = false;

        active = true;

    }

    protected virtual void set()
    {

        if (requireRoad)
        {
            Structure[] nei = getNeighbors();
            foreach (Structure s in nei)
            {
                if (s is Road && ((Road)s).connections[0] == true)
                {
                    hasRoad = true;
                    break;
                }
                else
                {
                    active = false;

                }
            }
        }
        if (requirePower)
        {
            Structure[] nei = getNeighbors();
            foreach (Structure s in nei)
            {
                if (s is Road && ((Road)s).connections[2] == true)
                {
                    hasPower = true;
                    break;
                }
                else
                {
                    active = false;

                }
            }
        }


    }

    protected virtual void onDay()
    {

    }
    protected virtual void OnMonths()
    {

    }
    protected void OnActive()
    {

    }
    protected void OnDeactive()
    {

    }


    public void setServicis(Service.typeOfService tos)
    {
        if (tos == Service.typeOfService.Police)
        {
            hasPolice = true;
        }
        if (tos == Service.typeOfService.Fire)
        {
            hasFire = true;
        }
        if (tos == Service.typeOfService.Healthcare)
        {
            hasHealtcare = true;
        }
    }
}
