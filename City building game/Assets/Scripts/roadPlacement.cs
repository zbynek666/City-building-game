using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using UnityEngine;
using UnityEngine.EventSystems;

public class roadPlacement : MonoBehaviour , IPointerClickHandler
{
    public GameObject building;

    private GameObject building2;
    private RaycastHit hit;
    private Vector2 p1;
    private Vector2 p2;


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
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (p1 == null) 
                        {
                            p1 = hit.point;
                        }
                        else if(p2 == null) 
                        {
                            p2 = hit.point;
                    //createRoad();
                        }
                    }
                }


    }

    private void createRoad(float x1,float x2) 
    {
        
    }

    private float getPointInGame(float x) 
    {
        return Mathf.Round(x);
    }

}
