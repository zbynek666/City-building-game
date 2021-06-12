using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    // Start is called before the first frame update
    Light lt;
    public bool active;
    public float time;
    public float timeLeft;

    void Start()
    {
        lt = gameObject.GetComponent<Light>();
        if (active)
        {
            lt.intensity = 3;
        }
        else
        {
            lt.intensity = 0;

        }

        timeLeft = time;
    }

    // Update is called once per frame
    void Update()
    {

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = time;
            active = !active;
            if (active)
            {
                lt.intensity = 3;

            }
            else
            {
                lt.intensity = 0;

            }

        }

    }
}
