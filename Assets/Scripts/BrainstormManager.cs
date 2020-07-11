﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainstormManager : MonoBehaviour
{
    [Header ("XML")]
    public string ideaXMLPath;

    private IdeasContainer ideaContainer;

    [Header ("Brainstorm")]
    public float brainstormTime;
    public int bubbleAmount;

    public int MaxIdeaQueue;

    private float[] timeStamps;

    private float elapsedTime = 0;
    private bool brainstormStarted = false;
    private int currentCheckedTimeStamp = 0;

    private List<Idea> activeIdeas;


    void Awake()
    {
        ideaContainer = IdeasContainer.Load(ideaXMLPath);
    }

    void Start()
    {
        timeStamps = new float[bubbleAmount];

        for(int i = 0; i < timeStamps.Length; i++)
        {
            timeStamps[i] = UnityEngine.Random.Range(0, brainstormTime - 2); //-2 so the player has min 2 second to read the last bubble;
        }

        Array.Sort(timeStamps);

    }

    void Update()
    {
        if(brainstormStarted && elapsedTime <= brainstormTime)
        {
            elapsedTime += Time.deltaTime;

            if(elapsedTime >= timeStamps[currentCheckedTimeStamp])
            {
                //activateIdea(here get a random idea from the idea container);

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

    public void activateIdea(Idea idea)
    {
        //this function mimics a queue behaviour by removing the first component of the list if the number of component exceeds the maximum amount

        activeIdeas.Add(idea);
        //request idea display to UI manager

        if (activeIdeas.Count > MaxIdeaQueue)
            activeIdeas.RemoveAt(0);
    }

    public void desactivateIdea(Idea idea, bool requestUI)
    {
        //desactivateIdea() can be called by the UI manager because he detected an idea removal from the user (he then deletes the idea sprite from the screen itself)
        //OR it can be called via an event then you must tell the UI manager to remove the idea sprite from the screen.

        activeIdeas.Remove(idea);

        
        if(requestUI)
        { }
            //request idea removal from the UI manager
    }
}
