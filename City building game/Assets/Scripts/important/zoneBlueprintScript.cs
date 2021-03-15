using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneBlueprintScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    RaycastHit hit;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 5000.0f, 1))
        {
            Vector2 s = GridManager.Instance.getRealPosition(GridManager.Instance.getPositionOnGrid(new Vector2(hit.point.x, hit.point.z)));
            transform.position = new Vector3(s.x, 0, s.y);
            if (Input.GetMouseButton(0) && GridManager.Instance.canPlaceZone(GridManager.Instance.getPositionOnGrid(new Vector2(hit.point.x, hit.point.z)), this.GetType()) == null &&
                GridManager.Instance.isNearRoad(GridManager.Instance.getPositionOnGrid(new Vector2(hit.point.x, hit.point.z))))
            {
                GameObject g = Instantiate(prefab, transform.position, transform.rotation);
                GridManager.Instance.addToPosition((int)GridManager.Instance.getPositionOnGrid(new Vector2(hit.point.x, hit.point.z)).x, (int)GridManager.Instance.getPositionOnGrid(new Vector2(hit.point.x, hit.point.z)).y, g.GetComponent<Structure>());

            }
        }
        if (Input.GetMouseButton(1))
        {
            Destroy(gameObject);
        }
    }
}
