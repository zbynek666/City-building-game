using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Service : RangeBuilding
{

    public enum typeOfService { Police, Fire, Healthcare };
    public typeOfService serviceType;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void rangeEffect()
    {
        foreach (Structure s in StructuresInRange)
        {
            if (s.GetType() == typeof(BasicBuilding))
            {
                ((BasicBuilding)s).reciceRangeEffects();
            }
        }
    }
}
