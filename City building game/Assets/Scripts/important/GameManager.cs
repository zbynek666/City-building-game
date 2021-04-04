using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject moneyLabel;
    public GameObject escMenu;

    public GameObject populationLabel;
    public GameObject moneyIncameLabel;
    public GameObject dateLabel;

    public GameObject placeSmoke;


    public UnityEvent onDay = new UnityEvent();
    public UnityEvent onMonths = new UnityEvent();

    private TextMeshProUGUI populationLabelText;
    private TextMeshProUGUI moneyIncameLabelText;
    private TextMeshProUGUI dateLabelText;


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
    }

    public void endOfDay()
    {

        onDay.Invoke();
        if (GlobalVariables.day >= 30)
        {
            if (GlobalVariables.month >= 12)
            {

                GlobalVariables.month = 0;
                GlobalVariables.year++;
            }
            endOfMonths();

            GlobalVariables.month++;


            GlobalVariables.day = 0;
        }
        GlobalVariables.day++;
        updateLabels();

    }

    private void endOfMonths()
    {
        onMonths.Invoke();
        updateLabels();
    }

    private void updateLabels()
    {
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
    }

    private int calculateIncome()
    {
        return 300;
    }


}
