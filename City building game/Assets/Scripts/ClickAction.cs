using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ClickAction : MonoBehaviour, IPointerClickHandler
{
    public GameObject cube;
    public GameObject spawnMark;

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("kys");
        Instantiate(cube.transform);
        }
    
}
