using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Service : RangeBuilding
{

    public enum typeOfService { Police, Fire, Healthcare };
    public typeOfService serviceType;
    public int expense;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    void Update()
    {

    }



    protected override void setEffect(Structure s)
    {

        Debug.Log(s);
        if (s is Building)
        {

            ((Building)s).setServicis(serviceType);
        }
    }


}
