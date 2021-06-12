using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int PowerConsumption { get; private set; }
    public int WaterConsumption { get; private set; }
    public int GarbageDisposalConsumption { get; private set; }
    public int SewageConsumption { get; private set; }
    /*
    public int PoliceNeed { get; private set; }
    public int FireNeed { get; private set; }
    public int HealthcareNeed { get; private set; }
    */
    public int PowerProduction { get; private set; }
    public int WaterProduction { get; private set; }
    public int GarbageDisposalProduction { get; private set; }
    public int SewageProduction { get; private set; }
    /*
    public int PoliceProduction { get; private set; }
    public int FireProduction { get; private set; }
    public int HealthcareProduction { get; private set; }
    */
    public void updateResources()
    {
        List<Structure> str = GridManager.Instance.getTypeOfObject<Building>();
        //Debug.Log(str.Count);
        updateConsumption(str);
        updateProduction(str);



    }

    private void updateConsumption(List<Structure> str)
    {
        PowerConsumption = 0;
        WaterConsumption = 0;
        GarbageDisposalConsumption = 0;
        SewageConsumption = 0;
        foreach (Structure s in str)
        {
            Building b = (Building)s;
            PowerConsumption += b.PowerConsumption;
            WaterConsumption += b.WaterConsumption;
            GarbageDisposalConsumption += b.GarbageDisposalConsumption;
            SewageConsumption += b.SewageConsumption;



        }
    }
    private void updateProduction(List<Structure> str)
    {
        PowerProduction = 0;
        WaterProduction = 0;
        GarbageDisposalProduction = 0;
        SewageProduction = 0;

        foreach (Structure s in str)
        {
            if (s is NeedsProvidingBuilding)
            {
                //Debug.Log(s);
                if (s is Power)
                {
                    PowerProduction += ((NeedsProvidingBuilding)s).prodiction;
                }
                if (s is Water)
                {
                    WaterProduction += ((NeedsProvidingBuilding)s).prodiction;
                }
                if (s is GarbageDisposal)
                {
                    GarbageDisposalProduction += ((NeedsProvidingBuilding)s).prodiction;
                }
                if (s is Sewage)
                {
                    SewageProduction += ((NeedsProvidingBuilding)s).prodiction;
                }
            }
            /*
            else if (s is Service)
            {
                Service ser = (Service)s;
                if (ser.serviceType == Service.typeOfService.Police)
                {

                }
            }
            */

        }

    }




}
