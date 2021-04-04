using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBuilding : Building
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
        GridManager.Instance.onBuild.AddListener(setStructuresInRange);
        setStructuresInRange();


    }

    // Update is called once per frame
    protected void setStructuresInRange()
    {
        List<Structure> strInRange = GridManager.Instance.getInRange(this);

    }
    protected virtual void dayRangeEffect()
    {

    }
    protected virtual void monthsRangeEffect()
    {

    }

}
