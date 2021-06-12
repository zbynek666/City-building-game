using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidencBulding : BasicBuilding
{
    void Start()
    {
        base.Start();


    }



    public ResidencBulding()
    {
        width = 1;
        height = 1;
    }
    protected override void clear()
    {
        base.clear();

    }
    protected override void set()
    {
        base.set();

    }

    protected override void onDay()
    {
        base.onDay();
    }

    protected override void OnMonths()
    {
        base.OnMonths();
    }

    public override void calculateHappines()
    {
        happines = HappinesBybuilding;
        happines += globalHappins;

        foreach (Structure s in getNeighbors())
        {
            if (s is ResidencBulding)
            {
                happines += 5;
                if (((ResidencBulding)s).happines > 50)
                {
                    happines += 5;

                    if (((ResidencBulding)s).happines > 100)
                    {
                        happines += 5;

                    }
                }

            }
        }
        happines += happisesByTaxes;

        if (happines > 100)
        {
            happines = 100;
        }
        else if (happines < 0)
        {
            happines = 0;
        }


    }
}
