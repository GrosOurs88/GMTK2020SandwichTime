using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idea
{


    public string text;
    public float fontSize = 42, bubbleWidth; //bubbleWidth is a percentage
    public int budgetChange, audienceChange, marketFitChange, prodValueChange;
    public BubbleType bubbleType;

    public Theme[] themes;
    public Character[] characters;
    public Event[] events;


    //public Idea(string _text, float _fontSize, float _bubbleWidth, int _budgetChange, int _audienceChange, int _marketFitChange, int _prodValueChange, BubbleType _bubbleType)
    //{
    //    themes = null;
    //    characters = null;
    //    events = null;
    //}
}

public enum BubbleType
{ }

public enum Theme
{ }


public enum Event
{ }

public class Character
{
    public string name;
    public Color bubbleColor;


}