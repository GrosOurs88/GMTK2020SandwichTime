using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timer;
    public TextMeshProUGUI timerUI;
    private bool meetingAlmostEnded = false;
    private bool meetingEnded = false;




    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }            

        if(timer <= 0f && meetingEnded)
        {
            meetingEnded = true;

            MasterSoundsScript.instance.PlayMeetingEnd();
            timer = 0f;
        }

        if(timer <= 10f && meetingAlmostEnded == false)
        {
            meetingAlmostEnded = true;

            MasterSoundsScript.instance.PlayMeetingAboutToEnd();
        }

        float minutes = (int)(timer / 60);
        float seconds = (int)(timer % 60);

        timerUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
