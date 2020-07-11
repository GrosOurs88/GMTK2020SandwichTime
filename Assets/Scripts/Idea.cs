using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idea
{


    public string text;
    public float fontSize, bubbleWidth; //bubbleWidth is a percentage
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