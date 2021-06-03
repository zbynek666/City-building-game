using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChanceForEvent()
    {
        foreach (Service.typeOfService serv in System.Enum.GetValues(typeof(Service.typeOfService)))
        {
            for (int i = 0; i < GlobalVariables.population / 100; i++)
            {
                int x = Random.Range(0, GridManager.Instance.width);
                int y = Random.Range(0, GridManager.Instance.height);

                Structure s = GridManager.Instance.getOnPosition(new Vector2(x, y));

                if (s != null && s is BasicBuilding)
                {
                    if (serv == Service.typeOfService.Fire)
                    {

                    }
                    else if (serv == Service.typeOfService.Healthcare)
                    {

                    }
                    else if (serv == Service.typeOfService.Police)
                    {

                    }
                }
            }
        }

    }
}
