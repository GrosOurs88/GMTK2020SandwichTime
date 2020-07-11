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
{
    Count
}

public enum Theme
{
    Count
}

public enum Character
{
    Count
}

public enum Event
{
    Count
}