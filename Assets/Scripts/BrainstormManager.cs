using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainstormManager : MonoBehaviour
{
    public float brainstormTime;
    public int bubbleAmount;

    private float[] timeStamps;

    // Start is called before the first frame update
    void Start()
    {
        timeStamps = new float[bubbleAmount];

        for(int i = 0; i < timeStamps.Length; i+)
        {
            timeStamps[i] = Random.Range(0, brainstormTime - 2); //-2 so the player has min 2 second to read the last bubble;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
