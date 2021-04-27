using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeBuilding : Building
{
    public int range;
    private List<Structure> StructuresInRange = new List<Structure>();
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


}
