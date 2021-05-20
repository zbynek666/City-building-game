using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicBuilding : Building
{
    public int maxPopulation;
    public int population;





    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
    }
    public bool[] info()
    {
        return new bool[] { hasRoad, hasMainCon, hasPower, hasWater };
    }

    public override void reciceRangeEffects()
    {

    }

    // Update is called once per frame


}
