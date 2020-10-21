using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class cubeMovement : MonoBehaviour
{
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            /*if ()
            {

            } 
            else 
            {
            
            }

            if ()
            {

            }
            else
            {

            }*/
            Debug.Log(((int)(hit.point.x)) % (10));


            this.transform.position = new Vector3(hit.point.x,1,hit.point.z) ;
        }
        
    }
}
