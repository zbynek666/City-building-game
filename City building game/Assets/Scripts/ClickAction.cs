using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ClickAction : MonoBehaviour, IPointerClickHandler
{
    public GameObject cube;

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("kys");
        Instantiate(cube,new Vector3(),new Quaternion());
        }
    
}
