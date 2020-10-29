using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class roadPlacement : MonoBehaviour , IPointerClickHandler
{
    public GameObject building;

    private GameObject building2;
    private RaycastHit hit;


    public void OnPointerClick(PointerEventData eventData)
    {
        building2 =  Instantiate(building, new Vector3(), new Quaternion());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame  
    void Update()
    {
        if (building != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {

                building.transform.position = new Vector3(Mathf.Round(hit.point.x), 1, Mathf.Round(hit.point.z));
            }
        }

    }
}
