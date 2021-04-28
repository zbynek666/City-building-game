using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : Building
{
    int connectionSlot = 1;
    public enum typeOfConnection { conn, mainBuilding, power, water }
    public typeOfConnection SelectedType;

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {

    }
    private void connect()
    {
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
    }
}
