using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidencBulding : BasicBuilding
{
    void Start()
    {
        base.Start();

        population = maxPopulation;
    }
    public ResidencBulding()
    {
        width = 1;
        height = 1;
    }



}
