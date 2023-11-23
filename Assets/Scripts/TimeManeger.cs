using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManeger : MonoBehaviour
{
    public Timer ti;
    public float TimeLeft;
    public bool TimerOn = false;
    

    public Text TimerText;


    // Start is called before the first frame update
    void Start()
    {
        ti.TimeLeftSave = TimeLeft;

    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn == true)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("tiden är slut");
                TimeLeft = 0;
                TimerOn = false;
                ti.TeleportBack = true;
            }
        }


        void updateTimer(float currentTime)
        {
            currentTime += 1;

            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);

            TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        }
    }
}
