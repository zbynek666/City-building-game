using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyEvent : UnityEvent<MapManager.TypesOfMap>
{
}
public class MapManager : MonoBehaviour
{
    public MyEvent changeColor = new MyEvent();
    public enum TypesOfMap { Original, Power, Water };
    public static MapManager Instance { get; private set; }
    public GameObject terain;
    private List<Color> originalMapColors = new List<Color>();




    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        foreach (Material m in terain.GetComponent<Renderer>().materials)
        {
            originalMapColors.Add(m.color);
        }
    }
    public void changeMap(TypesOfMap t)
    {
        if (t == TypesOfMap.Original)
        {
            for (int i = 0; i < originalMapColors.Count; i++)
            {
                terain.GetComponent<Renderer>().materials[i].color = originalMapColors[i];
            }
        }
        else
        {
            foreach (Material m in terain.GetComponent<Renderer>().materials)
            {
                m.color = new Color(0.6f, 0.6f, 0.6f);
            }
        }

        changeColor.Invoke(t);
    }



}
