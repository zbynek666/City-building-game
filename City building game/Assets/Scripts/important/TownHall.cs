using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHall : Building
{
    public GameObject mainPart;
    public int level = 1;
    private int Maxlevel = 5;
    public int expense;


    public GameObject[] otherparts;


    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        showParts(level);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Upgrade()
    {
        if (level < Maxlevel)
        {
            level++;

        }
        showParts(level);
    }
    public void showParts(int count)
    {
        for (int i = 0; i < Maxlevel; i++)
        {
            if (i + 1 <= count)
            {
                otherparts[i].SetActive(true);
            }
            else
            {
                otherparts[i].SetActive(false);

            }
        }
    }
    protected override void changeColor(MapManager.TypesOfMap t)
    {

    }
}
