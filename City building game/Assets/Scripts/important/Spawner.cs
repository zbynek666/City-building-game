using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] cars;
    public WayPoint firstWayPoint;
    public WayPoint secondWayPoint;

    public bool DestroyAfterSpawn;

    public bool toNextRoad;

    public int time;

    public bool spawnOnDay;


    System.Random rand;

    void Start()
    {
        //GameManager.Instance.onDay.AddListener(spawn);
        rand = new System.Random();

        if (spawnOnDay)
        {
            GameManager.Instance.onDay.AddListener(spawn);

        }


        if (DestroyAfterSpawn)
        {
            Invoke("spawn", rand.Next(1, time));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void spawn()
    {
        if (cars[0] != null)
        {
            if (toNextRoad)
            {


                Structure[] strs = gameObject.GetComponent<Structure>().getNeighbors();
                foreach (Structure s in strs)
                {
                    if (s is Road)
                    {
                        Movable c = Instantiate(cars[rand.Next(0, cars.Length)]).GetComponent<Movable>();
                        c.NextWaypoint = ((Road)s).carWayPoint1;
                        c.LastWaypoint = ((Road)s).carWayPoint1;
                        c.transform.position = ((Road)s).carWayPoint1.transform.position + new Vector3(4, 0, 0); ;
                        break;
                    }
                }
            }
            else
            {
                Movable c = Instantiate(cars[rand.Next(0, cars.Length)]).GetComponent<Movable>();
                c.NextWaypoint = firstWayPoint;
                c.LastWaypoint = secondWayPoint;
                c.transform.position = transform.position;
            }
        }

        if (DestroyAfterSpawn)
        {
            Destroy(this);

        }
    }
}
