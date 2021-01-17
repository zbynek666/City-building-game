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
                (Mathf.Round(hit.point.x / GridManager.Instance.gridsize) * GridManager.Instance.gridsize) + 5,
                hit.point.y,
                (Mathf.Round(hit.point.z / GridManager.Instance.gridsize) * GridManager.Instance.gridsize) + 5);

        }

        if (Input.GetMouseButton(0))
        {

            GameObject g = Instantiate(prefab, transform.position, transform.rotation);
            Structure s = g.GetComponent<Structure>();
            s.x = (int)transform.position.x / GridManager.Instance.gridsize;
            s.y = (int)transform.position.z / GridManager.Instance.gridsize;
            GridManager.Instance.addToPosition(s.x, s.y, s);
            foreach (Structure st in GridManager.Instance.g.gridArray)
            {
                if (st != null)
                {
                    st.kys();
                }
            }
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
