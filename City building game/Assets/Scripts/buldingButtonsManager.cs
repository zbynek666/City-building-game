using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buldingButtonsManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject prefab;

    public void spawnBlueprint() 
    {
        Instantiate(prefab);
    }
        
}
