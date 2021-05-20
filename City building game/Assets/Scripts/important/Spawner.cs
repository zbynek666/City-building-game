using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] cars;
    System.Random rand;

    void Start()
    {
        GameManager.Instance.onDay.AddListener(spawn);
        rand = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void spawn()
    {
        if (cars[0] != null)
        {
            Structure[] strs = gameObject.GetComponent<Structure>().getNeighbors();
            foreach (Structure s in strs)
            {
                if (s is Road)
                {
                    Movable c = Instantiate(cars[rand.Next(0, cars.Length)]).GetComponent<Movable>();
                    c.NextWaypoint = ((Road)s).carWayPoint1;
                    c.LastWaypoint = ((Road)s).carWayPoint1;
                    c.transform.position = transform.position;
                    break;
                }
            }
        }
    }
}
