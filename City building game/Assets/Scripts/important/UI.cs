using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject categoriesPanel;
    public GameObject categories;

    private List<Button> categoriesBtns = new List<Button>();
    private List<GameObject> categori = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in categories.transform)
        {
            categori.Add(child.gameObject);
        }
        int i = 0;

        foreach (Transform child in categoriesPanel.transform)
        {

            categoriesBtns.Add(child.GetComponent<Button>());

            child.GetComponent<Button>().onClick.AddListener(delegate { changeCategori(categori[categoriesBtns.IndexOf(child.GetComponent<Button>())]); });
            i++;


        }
        foreach (GameObject child in categori)
        {
            child.transform.GetChild(0).gameObject.GetComponent<Button>().onClick.AddListener(delegate { goToSelection(child); });
        }

    }

    // Update is called once per frame
    void Update()
    {



    }

    private void changeCategori(GameObject categori)
    {
        categoriesPanel.SetActive(false);
        categori.SetActive(true);
    }
    private void goToSelection(GameObject categori)
    {
        categoriesPanel.SetActive(true);
        categori.SetActive(false);
    }
}
