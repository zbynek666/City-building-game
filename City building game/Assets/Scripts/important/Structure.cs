using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public int width;
    public int height;
    public int x;
    public int y;
    private SpriteRenderer icon;

    public bool isPlaceByDefault;


    public virtual void Start()
    {

        Vector2 v = GridManager.Instance.getPositionOnGrid(new Vector2(transform.position.x, transform.position.z));
        x = (int)v.x;
        y = (int)v.y;

        if (isPlaceByDefault == true)
        {

            GridManager.Instance.addToPosition(x, y, this);

        }


    }



    protected void changeIcon(Sprite s)
    {
        if (icon == null)
        {
            GameObject objToSpawn = new GameObject("Icon");

            objToSpawn.transform.parent = this.gameObject.transform;
            objToSpawn.transform.localPosition = new Vector3(0, 5, 0);
            objToSpawn.transform.localScale = new Vector3(5, 5, 5);

            objToSpawn.AddComponent<Billbord>();
            objToSpawn.AddComponent<SpriteRenderer>();


            icon = objToSpawn.GetComponent<SpriteRenderer>();
        }
        icon.sprite = s;
    }

    public Structure[] getNeighbors()
    {
        Structure[] s = new Structure[4];

        s[0] = GridManager.Instance.getOnPosition(new Vector2(x + 1, y));
        s[1] = GridManager.Instance.getOnPosition(new Vector2(x - 1, y));
        s[2] = GridManager.Instance.getOnPosition(new Vector2(x, y - 1));
        s[3] = GridManager.Instance.getOnPosition(new Vector2(x, y + 1));



        return s;
    }

}
