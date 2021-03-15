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
    public GameObject pauseBtn;
    public GameObject speedBtn;
    public GameObject populationLabel;
    public GameObject TimeBar;
    public GameObject moneyIncameLabel;
    public GameObject dateLabel;
    public GameObject placeSmoke;





    private int[] speeds = new int[] { 10, 6, 3 };
    private int speedset = 0;
    private bool pauseToggle = false;
    private float timer = 0;
    private Vector3 timeBarSize = new Vector3(1, 1, 1);


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
        InvokeRepeating("updateAll", 0, speeds[0]);
        pauseBtn.GetComponent<Button>().onClick.AddListener(pause);
        speedBtn.GetComponent<Button>().onClick.AddListener(speedbtnClick);

    }




    //main cycle
    private void updateAll()
    {

        //actual thinks

        GlobalVariables.moneyIncome = calculateIncome();
        GlobalVariables.money += GlobalVariables.moneyIncome / 30;

        //update labels
        moneyLabel.GetComponent<TextMeshProUGUI>().text = GlobalVariables.money + "";
        moneyIncameLabel.GetComponent<TextMeshProUGUI>().text = "+" + GlobalVariables.moneyIncome;
        populationLabel.GetComponent<TextMeshProUGUI>().text = GlobalVariables.population + "";
        dateLabel.GetComponent<TextMeshProUGUI>().text = (GlobalVariables.day / 360 + 2020) + "/" + (((GlobalVariables.day % 360) / 30) + 1) + "/" + (((GlobalVariables.day % 360) % 30) + 1);


        GlobalVariables.day++;
        timer = 0;

    }

    private int calculateIncome()
    {
        return 300;
    }
    public void changeSpeed(int a)
    {

        if (a == -1)
        {
            CancelInvoke();

        }
        else
        {
            CancelInvoke();
            speedset = a;

            InvokeRepeating("updateAll", speeds[speedset] - timer, speeds[a]);
        }




    }
    public void exit()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);

    }

    public void pause()
    {
        if (pauseToggle)
        {
            changeSpeed(speedset);

        }
        else
        {
            changeSpeed(-1);
        }

        pauseToggle = !pauseToggle;
    }
    public void resume()
    {
        escMenu.SetActive(!pauseToggle);
        pauseToggle = !pauseToggle;

    }
    public void speedbtnClick()
    {
        if (speedset == 2)
        {
            changeSpeed(0);
        }
        else
        {
            changeSpeed(speedset + 1);
        }
    }

    void Update()
    {
        moneyLabel.GetComponent<TextMeshProUGUI>().text = GlobalVariables.money + "";
        populationLabel.GetComponent<TextMeshProUGUI>().text = PopulationManager.Instance.population + "";

        //

        if (!pauseToggle && TimeBar.transform.localScale.x < timeBarSize.x)
        {
            timer += Time.deltaTime;

        }
        if (TimeBar.transform.localScale.x > timeBarSize.x)
        {
            TimeBar.transform.localScale = new Vector3(timeBarSize.x, 1, 1);
        }

        TimeBar.transform.localScale = new Vector3(timer / speeds[speedset], 1, 1);




        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
            escMenu.SetActive(pauseToggle);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pause();

        }

    }

}
