using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public GameObject placeSmoke;


    public UnityEvent onDay = new UnityEvent();
    public UnityEvent onMonths = new UnityEvent();



    private PopulationManager populationManager = new PopulationManager();
    private UIMandager uIMandager = UIMandager.Instance;
    private ResourcesManager resourcesManager = new ResourcesManager();
    private EventManager eventManager = new EventManager();

    int currentFPS;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        currentFPS = (int)(1f / Time.unscaledDeltaTime);
        //Debug.Log(currentFPS);
    }
    void Start()
    {
        populationManager.UpdatePopulation();

        UIMandager.Instance.updateLabels();
    }

    public void endOfDay()
    {

        onDay.Invoke();
        if (GlobalVariables.day >= 30)
        {
            if (GlobalVariables.month >= 12)
            {

                GlobalVariables.month = 0;
                GlobalVariables.year++;
            }
            endOfMonths();

            GlobalVariables.month++;


            GlobalVariables.day = 0;
        }
        GlobalVariables.day++;
        populationManager.UpdatePopulation();
        resourcesManager.updateResources();
        UIMandager.Instance.updateLabels();




    }

    private void endOfMonths()
    {
        onMonths.Invoke();
        UIMandager.Instance.updateLabels();
    }



    private int calculateIncome()
    {
        return 300;
    }

    public Vector3 getZoneDemand()
    {

        return new Vector3(populationManager.residentDemand, populationManager.commercialDemand, populationManager.industrialDemand);
    }

    public int[] getResources()
    {
        return new int[] {
            resourcesManager.WaterProduction,resourcesManager.WaterConsumption,
            resourcesManager.PowerProduction,resourcesManager.PowerConsumption,
            resourcesManager.GarbageDisposalProduction,resourcesManager.GarbageDisposalConsumption,
            resourcesManager.SewageProduction,resourcesManager.SewageConsumption

        };
    }

}
