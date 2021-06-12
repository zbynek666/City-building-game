using System;
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

    public Button DebugBtn;
    public Button TestBtn;

    public GameObject rangeEffectCilinder;

    private GameObject rangeEffect;

    public GameObject SidePanel;
    public GameObject BottonBar;

    public GameObject MapInfo;


    public Animator BottonBarAnimator;
    public Animator SidePanelAnimator;

    public Button[] ChangeMapButtons;

    public GameObject IncomeBar;

    public TextMeshProUGUI ProductionLabel;
    public TextMeshProUGUI ConsumationLabel;
    public TextMeshProUGUI MapNameLabel;

    public Slider ResidanceTaxSlider;
    public Slider ComercialTaxSlider;
    public Slider IndustrialTaxSlider;

    public GameObject TaxWindow;
    public Button exitTaxWindow;


    public GameObject TownHallWindow;
    public Button exitTownHallWindow;
    public Button upgradeTownHallWindow;



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
        exitTaxWindow.onClick.AddListener(closeTaxWindow);
        ResidanceTaxSlider.onValueChanged.AddListener(MoveTaxSlider);
        ComercialTaxSlider.onValueChanged.AddListener(MoveTaxSlider);
        IndustrialTaxSlider.onValueChanged.AddListener(MoveTaxSlider);


        exitTownHallWindow.onClick.AddListener(closeTownHallWindow);
        upgradeTownHallWindow.onClick.AddListener(upgradeTownHall);


        DebugBtn.onClick.AddListener(GridManager.Instance.callEvents);
        TestBtn.onClick.AddListener(test);


        ChangeMapButtons[0].onClick.AddListener(delegate { MapManager.Instance.changeMap(MapManager.TypesOfMap.Original); });
        ChangeMapButtons[1].onClick.AddListener(delegate { MapManager.Instance.changeMap(MapManager.TypesOfMap.Power); });
        ChangeMapButtons[2].onClick.AddListener(delegate { MapManager.Instance.changeMap(MapManager.TypesOfMap.Water); });

        ChangeMapButtons[0].onClick.AddListener(delegate { showMapInfo(MapManager.TypesOfMap.Original); });
        ChangeMapButtons[1].onClick.AddListener(delegate { showMapInfo(MapManager.TypesOfMap.Power); });
        ChangeMapButtons[2].onClick.AddListener(delegate { showMapInfo(MapManager.TypesOfMap.Water); });




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

    private void test()
    {
        BottonBarAnimator.SetBool("show", !BottonBarAnimator.GetBool("show"));
        SidePanelAnimator.SetBool("show", !SidePanelAnimator.GetBool("show"));
        NotificationManager.Instance.ShowNotification(NotificationManager.TypeOfNotification.kys);


    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            if (TaxWindow.activeSelf)
            {
                TaxWindow.SetActive(false);

            }
            else
            {
                TaxWindow.SetActive(true);

            }

        }
        else if (Input.GetKeyDown("2"))
        {
            if (TownHallWindow.activeSelf)
            {
                TownHallWindow.SetActive(false);

            }
            else
            {
                TownHallWindow.SetActive(true);

            }
        }
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
        moneyIncameLabelText.text = GlobalVariables.moneyIncome + "";
        updateZoneBars();
        updateResourcesLabels();

    }

    private void updateResourcesLabels()
    {
        /*
        Debug.Log(GameManager.Instance.getResources());
        foreach (int i in GameManager.Instance.getResources())
        {
            Debug.Log(i);
        }
        */
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


        ResidentialBar.transform.localScale = new Vector3(ResidentialBar.transform.localScale.x, 1f / 100 * (GameManager.Instance.getZoneDemand().x + 1), ResidentialBar.transform.localScale.z);
        CommercialBar.transform.localScale = new Vector3(CommercialBar.transform.localScale.x, 1f / 100 * (GameManager.Instance.getZoneDemand().y + 1), CommercialBar.transform.localScale.z);
        IndustrialBar.transform.localScale = new Vector3(IndustrialBar.transform.localScale.x, 1f / 100 * (GameManager.Instance.getZoneDemand().z + 1), IndustrialBar.transform.localScale.z);

    }


    public void showBuildingInfo(Building bl)
    {
        Destroy(rangeEffect);
        if (bl is RangeBuilding)
        {

            rangeEffect = Instantiate(rangeEffectCilinder, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            rangeEffect.transform.position = bl.gameObject.transform.position;
            rangeEffect.transform.localScale = new Vector3(((RangeBuilding)bl).range * 10, 1, ((RangeBuilding)bl).range * 10);

        }
        else if (bl is BasicBuilding)
        {
            BasicBuildingInfo((BasicBuilding)bl);

        }
        else if (bl is TownHall)
        {
            ((TownHall)bl).Upgrade();

        }
        else
        {
        }
        BuildingInfoPanel.SetActive(true);

    }
    public void hideBuildingInfo()
    {
        BuildingInfoPanel.SetActive(false);
        Destroy(rangeEffect);
    }
    private void BasicBuildingInfo(BasicBuilding bb)
    {
        string[] info = bb.info();
        BuildingInfoPanel.transform.Find("info").GetComponent<TextMeshProUGUI>().text = "";

        BuildingInfoPanel.transform.Find("info").GetComponent<TextMeshProUGUI>().text += "population: " + info[7] + "/" + info[8] + " \u000a";


        BuildingInfoPanel.transform.Find("info").GetComponent<TextMeshProUGUI>().text += "Road: " + info[0] + " \u000a";
        BuildingInfoPanel.transform.Find("info").GetComponent<TextMeshProUGUI>().text += "Main connection: " + info[1] + " \u000a";
        BuildingInfoPanel.transform.Find("info").GetComponent<TextMeshProUGUI>().text += "Power: " + info[2] + " \u000a";
        BuildingInfoPanel.transform.Find("info").GetComponent<TextMeshProUGUI>().text += "Water: " + info[3] + " \u000a";
        BuildingInfoPanel.transform.Find("info").GetComponent<TextMeshProUGUI>().text += "Police: " + info[4] + " \u000a";
        BuildingInfoPanel.transform.Find("info").GetComponent<TextMeshProUGUI>().text += "Fire: " + info[5] + " \u000a";
        BuildingInfoPanel.transform.Find("info").GetComponent<TextMeshProUGUI>().text += "Healthcare: " + info[6] + " \u000a";
        BuildingInfoPanel.transform.Find("info").GetComponent<TextMeshProUGUI>().text += "Happines: " + info[9] + "/100 \u000a";





    }


    public void showBottonBar(bool b)
    {
        if (b)
        {
        }
        else
        {
        }
    }
    public void showSidePanel(bool b)
    {
        if (b)
        {
        }
        else
        {
        }
    }

    public void showMapInfo(MapManager.TypesOfMap m)
    {
        if (m == MapManager.TypesOfMap.Original)
        {
            MapInfo.SetActive(false);
            return;

        }
        float prod = 0;
        float cons = 0;

        MapInfo.SetActive(true);
        if (m == MapManager.TypesOfMap.Water)
        {

            prod = GameManager.Instance.getResources()[0];
            cons = GameManager.Instance.getResources()[1] + 1f;

            MapNameLabel.text = "Water";
            ProductionLabel.text = "Production :" + prod + "MW/Day";
            ConsumationLabel.text = "Consumation" + cons + "MW / Day";

        }
        if (m == MapManager.TypesOfMap.Power)
        {


            prod = GameManager.Instance.getResources()[2];
            cons = GameManager.Instance.getResources()[3] + 1f;

            ProductionLabel.text = "Production: " + prod + "m" + "\xB3" + "/Day";
            ConsumationLabel.text = "Consumation: " + cons + "m" + "\xB3" + "/ Day";
            MapNameLabel.text = "Power";

        }


        if (prod / cons > 2)
        {
            IncomeBar.transform.localPosition = new Vector3(200, 8, 0);

        }
        else if (prod / cons < 0)
        {
            IncomeBar.transform.localPosition = new Vector3(0, 8, 0);

        }
        else
        {
            IncomeBar.transform.localPosition = new Vector3(((prod / cons)) * 100, 8, 0);

        }



    }


    public void closeMapInfo()
    {
        MapInfo.SetActive(false);

        MapManager.Instance.changeMap(MapManager.TypesOfMap.Original);
    }

    public void MoveTaxSlider(float f)
    {
        float res = 0;
        float com = 0;
        float ind = 0;

        res = ResidanceTaxSlider.value;
        com = ComercialTaxSlider.value;
        ind = IndustrialTaxSlider.value;


        GameManager.Instance.setTaxes(res / 20, com / 20, ind / 20);




    }
    public void closeTaxWindow()
    {
        TaxWindow.SetActive(false);
    }


    public void closeTownHallWindow()
    {
        TownHallWindow.SetActive(false);
    }

    public void upgradeTownHall()
    {
        foreach (Structure s in GridManager.Instance.getTypeOfObject<TownHall>())
        {
            ((TownHall)s).Upgrade();
        }
    }




}
