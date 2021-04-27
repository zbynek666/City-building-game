using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    Transform selection;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5000.0f, 1 << LayerMask.NameToLayer("Ground")))
        {
            selection = hit.transform;
            Debug.Log(hit.transform);

            //var selectionRenderer = selection.GetComponent<Renderer>();

        }
        if ((Input.GetMouseButtonDown(0)))
        {

            UIMandager.Instance.showBuildingInfo();

        }

    }

}
