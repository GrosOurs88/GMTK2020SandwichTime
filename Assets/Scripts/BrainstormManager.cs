using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainstormManager : MonoBehaviour
{
    public float brainstormTime;
    public int bubbleAmount;

    private float[] timeStamps;

    private float elapsedTime = 0;
    private bool brainstormStarted = false;
    private int currentCheckedTimeStamp = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeStamps = new float[bubbleAmount];

        for(int i = 0; i < timeStamps.Length; i++)
        {
            timeStamps[i] = UnityEngine.Random.Range(0, brainstormTime - 2); //-2 so the player has min 2 second to read the last bubble;
        }

        Array.Sort(timeStamps);

    }

    // Update is called once per frame
    void Update()
    {
        if(brainstormStarted && elapsedTime <= brainstormTime)
        {
            elapsedTime += Time.deltaTime;

            if(elapsedTime >= timeStamps[currentCheckedTimeStamp])
            {
                //request bubble display
                Debug.Log("display bubble");

                if(currentCheckedTimeStamp < timeStamps.Length - 1)
                    currentCheckedTimeStamp++ ;
            }
        }
    }

    void startBrainstorm()
    {
        brainstormStarted = true;
        elapsedTime = 0;
    }
}
