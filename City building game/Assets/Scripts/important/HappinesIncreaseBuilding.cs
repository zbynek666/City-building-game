using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinesIncreaseBuilding : RangeBuilding
{

    public int Strenth = 10;

    // Start is called before the first frame update
    protected override void setEffect(Structure s)
    {
        if (s is ResidencBulding)
        {
            ResidencBulding rb = ((ResidencBulding)s);
            rb.addHappines(Strenth);
        }
    }
}



