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
        base.Start();

    }

    // Update is called once per frame
    void Update()
    {

    }



    protected override void setEffect()
    {
        Debug.Log(StructuresInRange.Count);
        foreach (Structure s in StructuresInRange)
        {
            Debug.Log(s);
            if (s is Building)
            {

                ((Building)s).setServicis(serviceType);
            }
        }
    }
}
