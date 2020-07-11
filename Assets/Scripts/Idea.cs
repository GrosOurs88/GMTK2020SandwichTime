using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idea : MonoBehaviour
{


    public string text;
    public float textSize;
    public int budgetChange, audienceChange, marketFitChange, prodValueChange;
    public BubbleType bubbleType;

    public Theme[] themes;
    public Character[] characters;
    public Event[] events;

    


}

public enum BubbleType
{ }

public enum Theme
{ }

public enum Character
{ }

public enum Event
{ }