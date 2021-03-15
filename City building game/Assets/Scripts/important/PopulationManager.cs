using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static PopulationManager Instance { get; private set; }
    public int population { get; private set; }
    private int residentDemand = 100;
    private int commercialDemand = 100;
    private int industrialDemand = 100;


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
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        calculatePopulation();

    }
    private void calculatePopulation()
    {
        int p = 0;
        List<Structure> r = GridManager.Instance.getTypeOfObject<Residenc>();
        List<Residenc> rr = new List<Residenc>();
        for (int i = 0; i < r.Count; i++)
        {
            rr.Add((Residenc)r[i]);
        }
        for (int i = 0; i < rr.Count; i++)
        {
            p += rr[i].actualnumberOfpeople;

        }
        population = p;



    }
}
