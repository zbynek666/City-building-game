﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float residentDemand { get; private set; }
    public float commercialDemand { get; private set; }
    public float industrialDemand { get; private set; }




    // Update is called once per frame

    public void UpdatePopulation()
    {
        calculatePopulation();
        calculateZoneDemand();
    }

    private void calculatePopulation()
    {
        int p = 0;
        List<Structure> r = GridManager.Instance.getTypeOfObject<ResidencBulding>();
        List<ResidencBulding> rr = new List<ResidencBulding>();
        for (int i = 0; i < r.Count; i++)
        {
            rr.Add((ResidencBulding)r[i]);
        }
        for (int i = 0; i < rr.Count; i++)
        {
            p += rr[i].population;

        }

        GlobalVariables.population = p;



    }
    private void calculateZoneDemand()
    {

        float res = 1;
        float ind = 1;
        float com = 1;
        //calculate resinance zone



        List<Structure> str = GridManager.Instance.getTypeOfObject<Zone>();

        for (int i = 0; i < str.Count; i++)
        {
            if (((Zone)str[i]).zone == Zone.typeOfZone.resident)
            {
                res += 5;
            }
        }

        res += GlobalVariables.population;


        //calculate industrial zone
        str = GridManager.Instance.getTypeOfObject<Zone>();

        for (int i = 0; i < str.Count; i++)
        {
            if (((Zone)str[i]).zone == Zone.typeOfZone.industrial)
            {
                ind += 5;
            }
        }

        str = GridManager.Instance.getTypeOfObject<IndustrialBuilding>();

        for (int i = 0; i < str.Count; i++)
        {
            res += ((IndustrialBuilding)str[i]).population;
        }


        //calculate comercial zone
        str = GridManager.Instance.getTypeOfObject<Zone>();

        for (int i = 0; i < str.Count; i++)
        {
            if (((Zone)str[i]).zone == Zone.typeOfZone.industrial)
            {
                ind += 5;
            }
        }

        str = GridManager.Instance.getTypeOfObject<ComercialBuilding>();

        for (int i = 0; i < str.Count; i++)
        {
            ind += ((ComercialBuilding)str[i]).population;
        }
        /*
        res = 300;
        com = 100;
        ind = 20;
        */
        /*residentDemand += 1f + (res / com+ind);
        industrialDemand = 0;
        commercialDemand = 0;
        */
        residentDemand = (((com + ind) - res) / res) * 100f;
        commercialDemand = ((res / 2 - (com)) / res) * 2 * 100f;
        industrialDemand = ((com - (ind)) / res) * 2 * 100f;


        if (residentDemand < 0)
            residentDemand = 0;
        if (commercialDemand < 0)
            commercialDemand = 0;
        if (industrialDemand < 0)
            industrialDemand = 0;


        if (residentDemand > 100)
            residentDemand = 100;
        if (commercialDemand > 100)
            commercialDemand = 100;
        if (industrialDemand > 100)
            industrialDemand = 100;






    }

    public void addPopulation()
    {
        List<Structure> r = GridManager.Instance.getTypeOfObject<ResidencBulding>();
        List<ResidencBulding> rr = new List<ResidencBulding>();
        int maxAddedPopulation = 0;
        for (int i = 0; i < r.Count; i++)
        {
            ResidencBulding a = (ResidencBulding)r[i];
            maxAddedPopulation += a.maxPopulation - a.population;
            rr.Add(a);
        }
        int populationAdded = (int)(((GlobalVariables.population / 10f) + 10) * (residentDemand / 100));

        if (populationAdded > maxAddedPopulation)
        {
            populationAdded = maxAddedPopulation;
        }
        while (true)
        {
            foreach (ResidencBulding rb in rr)
            {
                if (rb.population < rb.maxPopulation)
                {
                    rb.population++;
                    populationAdded--;
                }
                if (populationAdded <= 0)
                {
                    break;

                }
            }
            if (populationAdded <= 0)
            {
                break;

            }
        }
    }
}
