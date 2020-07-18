using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerUI;
    private bool meetingAlmostEnded = false;
    private bool meetingEnded = false;

    public BrainstormManager bsManager;

    private float timeTotal;

    private void Start()
    {
        timeTotal = bsManager.brainstormTime;
    }


    void Update()
    {
        //if (timer > 0f)
        //{
        //    timer -= Time.deltaTime;
        //}            
        float timer = timeTotal - bsManager.getElapsedTime();

        if (timer <= 0f && meetingEnded)
        {
            meetingEnded = true;

            MasterSoundsScript.instance.PlayMeetingEnd();
            timer = 0f;
        }

        if (timer <= 10f && meetingAlmostEnded == false)
        {
            meetingAlmostEnded = true;

            MasterSoundsScript.instance.PlayMeetingAboutToEnd();
        }

        timerUI.text = ((int)timer).ToString();


        // float minutes = (int)(timer / 60);
        // float seconds = (int)(timer % 60);

        //timerUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
