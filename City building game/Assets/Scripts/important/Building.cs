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




    public bool active;

    protected bool hasRoad;
    protected bool hasMainCon;
    protected bool hasPower;
    protected bool hasWater;
    protected bool hasPolice;



    protected void Start()
    {
        base.Start();

        gameObject.AddComponent<MeshCollider>();
        GridManager.Instance.beforeBuild.AddListener(clear);
        GridManager.Instance.afterRoadConnections.AddListener(set);
        GameManager.Instance.onDay.AddListener(onDay);
        GameManager.Instance.onMonths.AddListener(OnMonths);
        set();

    }

    // Update is called once per frame


    protected virtual void clear()
    {
        active = false;
        hasRoad = false;
        hasMainCon = false;
        hasPower = false;
        hasWater = false;
        hasPolice = false;
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
            }
        }

        active = true;

        if (active)
        {
            OnActive();
        }
        else
        {
            OnDeactive();
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
    public virtual void reciceRangeEffects()
    {

    }
}
