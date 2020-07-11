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

    private float[] timeStamps;


    void Awake()
    {
        ideaContainer = IdeasContainer.Load(ideaXMLPath);
    }

    void Start()
    {
        timeStamps = new float[bubbleAmount];

        for(int i = 0; i < timeStamps.Length; i++)
        {
            timeStamps[i] = Random.Range(0, brainstormTime - 2); //-2 so the player has min 2 second to read the last bubble;
        }
    }

    void Update()
    {
        
    }
}
