using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("IdeaRoot")]
public class Idea
{

    
    public string text;
    public float fontSize = 42, bubbleWidth=1; //bubbleWidth is a percentage
    public int budgetChange;
    public int pegi;
    public int appealing;

    [XmlArray("Themes")]
    [XmlArrayItem("Theme")]
    public Theme[] themes;

    [XmlArray("Characters")]
    [XmlArrayItem("Character")]
    public int[] characters;

    [XmlArray("Events")]
    [XmlArrayItem("Event")]
    public Event[] events;

}


public enum Theme
{
    pirate,
    scifi,
    space,
    fantasy,
    western,
    historical,
    nature,
    kid,
    postapo,
    count
}


public enum Event
{
    Count
}

public enum Character
{
    Chantal,
    Boss,
    Surfer,
    Gay,
    Token,
    Woman,
    Fabrice,
    Count
}
