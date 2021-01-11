using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject moneyLabel;
    private int[] speeds = new int[] { 10, 6, 3 };
    private int speedset = 1;
    private bool pauseToggle = false;
    public GameObject escMenu;

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
        InvokeRepeating("updateAll", speeds[0], speeds[0]);
    }


    //main cycle
    private void updateAll()
    {

        //actual thinks
        GlobalVariables.moneyIncome = calculateIncome();
        GlobalVariables.money += GlobalVariables.moneyIncome / 30;

        //player info
        moneyLabel.GetComponent<TextMeshProUGUI>().text = GlobalVariables.money + "+" + GlobalVariables.moneyIncome;

    }

    private int calculateIncome()
    {
        return 300;
    }
    public void changeSpeed()
    {
        if (pauseToggle)
        {
            CancelInvoke();
        }
        else
        {
            CancelInvoke();
            InvokeRepeating("updateAll", speeds[speedset], speeds[speedset]);

        }
    }
    public void pause()
    {
        if (pauseToggle)
        {
            changeSpeed();
        }
        else
        {
            changeSpeed();
        }
        escMenu.SetActive(!pauseToggle);

        pauseToggle = !pauseToggle;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
    }
}
