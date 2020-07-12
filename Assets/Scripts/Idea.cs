using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("IdeaRoot")]
public class Idea
{

    
    public string text;
    public float fontSize = 42, bubbleWidth; //bubbleWidth is a percentage
    public int budgetChange, pegi,appealing;
    public BubbleType bubbleType;

    [XmlArray("Themes")]
    [XmlArrayItem("Theme")]
    public Theme[] themes;

    [XmlArray("Characters")]
    [XmlArrayItem("Character")]
    public int[] characters;

    [XmlArray("Events")]
    [XmlArrayItem("Event")]
    public Event[] events;


    //public Idea(string _text, float _fontSize, float _bubbleWidth, int _budgetChange, int _audienceChange, int _marketFitChange, int _prodValueChange, BubbleType _bubbleType)
    //{
    //    themes = null;
    //    characters = null;
    //    events = null;
    //}
}

public enum BubbleType
{
    Count
}

public enum Theme
{
    pirate,
    scifi,
    fantasy,
    space,
    western,
    count
}


public enum Event
{
    Count
}

public enum Character
{
    Count
}
