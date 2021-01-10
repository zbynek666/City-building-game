using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject moneyLabel;
    private int[] speeds = new int[] { 10, 6, 3 };
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
    public void changeSpeed(int speed)
    {
        if (speed == 0)
        {
            CancelInvoke();
        }
        else
        {
            CancelInvoke();
            InvokeRepeating("updateAll", speeds[speed], speeds[speed]);

        }
    }
}
