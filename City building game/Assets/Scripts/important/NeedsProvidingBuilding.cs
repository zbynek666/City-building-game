using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NeedsProvidingBuilding : Building
{
    // Start is called before the first frame update
    int connectionSlot = -1;
    public enum typeOfConnection { conn, mainBuilding, power, water }
    public typeOfConnection SelectedType;
    public int prodiction;

    protected void Start()
    {
        base.Start();
        GridManager.Instance.onBuild.AddListener(connect);
        GridManager.Instance.callEvents();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void selectConnection()
    {
        if (SelectedType == typeOfConnection.conn)
        {
            connectionSlot = 0;
        }
        else if (SelectedType == typeOfConnection.mainBuilding)
        {
            connectionSlot = 1;

        }
        else if (SelectedType == typeOfConnection.power)
        {
            connectionSlot = 2;

        }
        else if (SelectedType == typeOfConnection.water)
        {
            connectionSlot = 3;

        }
    }
    protected void connect()
    {
        if (connectionSlot == -1)
        {
            selectConnection();
        }
        Structure[] nei = getNeighbors();
        foreach (Structure s in nei)
        {
            if (s is Road)
            {
                bool[] con = new bool[4];
                for (int i = 0; i < con.Length; i++)
                {
                    if (i == connectionSlot)
                    {
                        con[i] = true;
                    }
                }
                ((Road)s).connect(con);
            }
        }
        Debug.Log("connect to road " + connectionSlot);

    }
}
