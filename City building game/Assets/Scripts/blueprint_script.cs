using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueprint_script : MonoBehaviour
{

    RaycastHit hit;
    Vector3 movepoint;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.position = hit.point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 5000.0f, 1))
        {
            transform.position = new Vector3(
                Mathf.Round(hit.point.x / 10.0f) * 10.0f,
                hit.point.y,
                Mathf.Round(hit.point.z / 10.0f) * 10.0f);
        }

        if (Input.GetMouseButton(0))
        {

            Instantiate(prefab, transform.position, transform.rotation);
            //nont know why it doesnt work
            if (Input.GetKeyDown("left shift"))
            {
                Debug.Log("kys");
            }
            else
            {
                Destroy(gameObject);
            }

        }

    }
}
