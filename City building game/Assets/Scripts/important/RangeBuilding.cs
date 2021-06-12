using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeBuilding : Building
{
    public int range;
    protected List<Structure> StructuresInRange = new List<Structure>();
    public int expense;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        if (width % 2 == 0 && height % 2 == 0)
        {
            Debug.LogError("RangeBuilding have wrong size");
        }
        set();


    }

    // Update is called once per frame

    protected override void clear()
    {
        base.clear();
        StructuresInRange.Clear();
    }

    protected override void set()
    {
        base.set();
        StructuresInRange = GridManager.Instance.getInRange(this);




    }
    protected override void onDay()
    {
        if (StructuresInRange.Count > 0)
        {
            foreach (Structure s in StructuresInRange)
            {
                setEffect(s);

            }
        }
    }


    protected abstract void setEffect(Structure s);


}
