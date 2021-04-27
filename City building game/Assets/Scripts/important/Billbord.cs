using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billbord : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPoint = Camera.main.transform.position;

        var lookPos = targetPoint - transform.position;
        //lookPos.x = 0;


        var rotation = Quaternion.LookRotation(lookPos);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 100);
        transform.rotation = Quaternion.Euler(rotation.eulerAngles.x + 90, Camera.main.transform.parent.rotation.eulerAngles.y, rotation.eulerAngles.z);



    }
}