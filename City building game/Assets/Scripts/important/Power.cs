using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : NeedsProvidingBuilding
{


    // Start is called before the first frame update
    void Start()
    {
        GridManager.Instance.onBuild.AddListener(connect);
        GridManager.Instance.callEvents();
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void clear()
    {
    }

    protected override void onDay()
    {
    }

    protected override void OnMonths()
    {
    }

    protected override void set()
    {
    }
    private void connect()
    {
        Structure[] nei = getNeighbors();
        foreach (Structure s in nei)
        {
            if (s is Road)
            {
                ((Road)s).connect(new bool[] { false, true, false });
            }
        }
    }
}
