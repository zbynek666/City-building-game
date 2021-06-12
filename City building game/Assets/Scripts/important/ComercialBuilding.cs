using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComercialBuilding : BasicBuilding
{


    // Start is called before the first frame update


    void Start()
    {
        base.Start();

        population = maxPopulation;

    }

    // Update is called once per frame
    void Update()
    {

    }


    protected override void onDay()
    {
        base.onDay();
    }

    protected override void OnMonths()
    {
        base.onDay();
    }
    protected override void clear()
    {
        base.clear();

    }
    protected override void set()
    {
        base.set();

    }

    public override void calculateHappines()
    {
        throw new System.NotImplementedException();
    }
}
