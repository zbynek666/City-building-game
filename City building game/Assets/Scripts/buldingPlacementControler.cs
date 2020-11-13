using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buldingPlacementControler : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectPrefab;

    private RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void newObjectMovement() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {

            this.transform.position = new Vector3(Mathf.Round(hit.point.x), 1, Mathf.Round(hit.point.z));
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(gameObjectPrefab, this.transform.position, this.transform.rotation);
            if (!(Input.GetKey(KeyCode.LeftShift)))
            {
                enabled = false;
            }

        }
    }
}
