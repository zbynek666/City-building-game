using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : Structure
{
    float timeLeft;
    public GameObject building;
    public enum typeOfZone { resident, commercial, industrial }

    public typeOfZone zone;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = UnityEngine.Random.Range(3, 10);
        if (zone == typeOfZone.resident)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            spownHouse();
            Destroy(gameObject);
        }

    }

    private void spownHouse()
    {
        GameObject g = Instantiate(building, transform.position, transform.rotation);
        Vector2 pos = GridManager.Instance.getPositionOnGrid(new Vector2(transform.position.x, transform.position.z));
        GridManager.Instance.addToPosition((int)pos.x, (int)pos.y, g.GetComponent<Residenc>());

    }
}
