using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedManager : MonoBehaviour
{
    public Button pauseBtn;
    public Button speedBtn;
    public GameObject TimeBar;



    public bool playing = true;



    private float tick = 0.01f;
    private float timer = 0;
    private float dayLength = 1000;
    private float dayProgress;
    private float speed = 1;
    private int[] speeds = new int[] { 1, 3, 5 };

    void Start()
    {
        pauseBtn.onClick.AddListener(pause);
        speedBtn.onClick.AddListener(changeSpeed);
    }

    void Update()
    {
        updateTime();
    }

    private void changeSpeed()
    {
        if (speed == speeds[0])
        {
            speed = speeds[1];
        }
        else if (speed == speeds[1])
        {
            speed = speeds[2];

        }
        else if (speed == speeds[2])
        {
            speed = speeds[0];

        }
    }

    private void pause()
    {
        playing = !playing;
    }

    public void updateTime()
    {
        timer += Time.deltaTime;

        if (timer > tick)
        {

            if (playing)
            {

                dayProgress += speed;
                TimeBar.transform.localScale = new Vector3(1 * ((dayProgress / dayLength)), TimeBar.transform.localScale.y, TimeBar.transform.localScale.z);

                if (dayProgress >= dayLength)
                {
                    GameManager.Instance.endOfDay();
                    dayProgress = 0;
                }

            }
            timer = timer - tick;

        }



    }
}
