using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMandager : MonoBehaviour
{
    public static UIMandager Instance { get; private set; }
    //menus
    public GameObject escMenu;

    //labels
    public GameObject populationLabel;
    public GameObject moneyIncameLabel;
    public GameObject dateLabel;
    public GameObject moneyLabel;

    //bars
    public GameObject ResidentialBar;
    public GameObject CommercialBar;
    public GameObject IndustrialBar;

    //text from labels
    private TextMeshProUGUI populationLabelText;
    private TextMeshProUGUI moneyIncameLabelText;
    private TextMeshProUGUI dateLabelText;
    private TextMeshProUGUI moneyLabelText;

    //categiries
    public GameObject categoriesPanel;
    public GameObject categories;

    private List<Button> categoriesBtns = new List<Button>();
    private List<GameObject> categori = new List<GameObject>();

    public GameObject BuildingInfoPanel;




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


    void Start()
    {
        populationLabelText = populationLabel.GetComponent<TextMeshProUGUI>();
        moneyIncameLabelText = moneyIncameLabel.GetComponent<TextMeshProUGUI>();
        dateLabelText = dateLabel.GetComponent<TextMeshProUGUI>();
        moneyLabelText = moneyLabel.GetComponent<TextMeshProUGUI>();

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


    void Update()
    {

    }
    public void updateLabels()
    {
        populationLabelText.text = GlobalVariables.population + "";
        dateLabelText.text = GlobalVariables.year + "/";
        if (GlobalVariables.month < 10)
        {
            dateLabelText.text += 0 + "" + GlobalVariables.month + "/";
        }
        else
        {
            dateLabelText.text += GlobalVariables.month + "/";

        }

        if (GlobalVariables.day < 10)
        {
            dateLabelText.text += 0 + "" + GlobalVariables.day;
        }
        else
        {
            dateLabelText.text += GlobalVariables.day;
        }
        moneyLabelText.text = GlobalVariables.money + "";
        updateZoneBars();
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

    private void updateZoneBars()
    {

        ResidentialBar.transform.localScale = new Vector3(ResidentialBar.transform.localScale.x, 1f / 100 * GameManager.Instance.getZoneDemand().x, ResidentialBar.transform.localScale.z);
        CommercialBar.transform.localScale = new Vector3(CommercialBar.transform.localScale.x, 1f / 100 * GameManager.Instance.getZoneDemand().y, CommercialBar.transform.localScale.z);
        IndustrialBar.transform.localScale = new Vector3(IndustrialBar.transform.localScale.x, 1f / 100 * GameManager.Instance.getZoneDemand().z, IndustrialBar.transform.localScale.z);

    }

    public void showBuildingInfo(Building bl)
    {
        if (bl is BasicBuilding)
        {
            writeBasicBuildingInfo((BasicBuilding)bl);
        }
        else
        {
        }
        BuildingInfoPanel.SetActive(true);

    }
    public void hideBuildingInfo()
    {
        BuildingInfoPanel.SetActive(false);
    }
    private void writeBasicBuildingInfo(BasicBuilding bb)
    {
        bool[] info = bb.info();
        BuildingInfoPanel.transform.Find("info").GetComponent<TextMeshProUGUI>().text = "";
        for (int i = 0; i < info.Length; i++)
        {
            BuildingInfoPanel.transform.Find("info").GetComponent<TextMeshProUGUI>().text += info[i] + " \u000a";

        }
    }
}
