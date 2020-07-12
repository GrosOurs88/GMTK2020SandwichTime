using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainstormManager : MonoBehaviour
{

    [Header ("Brainstorm")]
    public float brainstormTime;
    public int bubbleAmount;

    public int MaxIdeaQueue;

    private float[] timeStamps;

    private float elapsedTime = 0;
    public bool brainstormStarted = false;
    public RoomController roomController;

    private int currentCheckedTimeStamp = 0;

    private IdeasContainer ideaContainer;
    private List<Idea> activeIdeas;
    private List<Idea> ideas;

    private Pitch[] pitchs;
    public Pitch selectedPitch;

    public WhiteBoardManager wbManager;

    void Awake()
    {
        ideaContainer = IdeasContainer.Load();

        pitchs = Resources.LoadAll<Pitch>("Pitchs");

        selectedPitch = getRandomPitch();

        wbManager.objective = selectedPitch;
    }

    void Start()
    {
        roomController.IdeaDiscarded += desactivateIdea;
        roomController.IdeaSelected += desactivateIdea;

        activeIdeas = new List<Idea>();
        timeStamps = new float[bubbleAmount];

        for(int i = 0; i < timeStamps.Length; i++)
        {
            timeStamps[i] = UnityEngine.Random.Range(0, brainstormTime - 2); //-2 so the player has min 2 second to read the last bubble;
        }

        Array.Sort(timeStamps);

        

        //startBrainstorm();

    }

    void Update()
    {
        if(brainstormStarted && elapsedTime <= brainstormTime)
        {
            elapsedTime += Time.deltaTime;

            if (currentCheckedTimeStamp < timeStamps.Length)
            {
                if (elapsedTime >= timeStamps[currentCheckedTimeStamp])
                {
                    

                    activateIdea(getRandomIdea());
                    currentCheckedTimeStamp++;
                }
            }
        }

        if (elapsedTime >= brainstormTime)
        {
            Debug.Log(wbManager.getResult());
        }
       

    }

    public void startBrainstorm()
    {
        brainstormStarted = true;
        elapsedTime = 0;

        ideas = ideaContainer.ideas;
    }

    public void activateIdea(Idea idea)
    {
        //this function mimics a queue behaviour by removing the first component of the list if the number of component exceeds the maximum amount

        activeIdeas.Add(idea);
        roomController.DisplayIdeaBubble(idea);

        Debug.Log("display bubble");

        if (activeIdeas.Count > MaxIdeaQueue)
        {
            desactivateIdeaRequest(activeIdeas[0]);
        }
    }

    public void desactivateIdeaRequest(Idea idea)
    {
        //desactivateIdea() can be called by the UI manager because he detected an idea removal from the user (he then deletes the idea sprite from the screen itself)
        //OR it can be called via an event then you must tell the UI manager to remove the idea sprite from the screen.

        activeIdeas.Remove(idea);

        //request idea removal from the UI manager
        roomController.RemoveBubble(idea);

    }


    public void desactivateIdea(Idea idea)
    {

        activeIdeas.Remove(idea);
    }

    private Idea getRandomIdea()
    {
        if(ideas.Count <= 0)
        {
            Debug.LogError("Ran out of ideas, the amount of ideas in the xml should be higher or equal to the bubbleAmount");
        }

        Idea idea = ideas[UnityEngine.Random.Range(0, ideas.Count)];
        ideas.Remove(idea);

        return idea;
    }

    private Pitch getRandomPitch()
    {
        return pitchs[UnityEngine.Random.Range(0, pitchs.Length)];
    }
}
