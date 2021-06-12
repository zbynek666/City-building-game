using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    int layer_mask;
    Transform selection;
    private void Start()
    {
        layer_mask = LayerMask.GetMask("Ground", "Building");

    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Debug.Log(LayerMask.NameToLayer("Building"));

        if (Physics.Raycast(ray, out hit, 5000.0f, layer_mask))
        {

            selection = hit.transform;


            //var selectionRenderer = selection.GetComponent<Renderer>();

        }
        if ((Input.GetMouseButtonDown(0)))
        {
            if (selection.gameObject.GetComponent<Structure>() != null)
            {
                UIMandager.Instance.showBuildingInfo(selection.gameObject.GetComponent<Building>());


            }

        }

    }

}
