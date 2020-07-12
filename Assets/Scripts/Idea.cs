using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("IdeaRoot")]
public class Idea
{

    
    public string text, title; //the title is only one word
    public int fontSize = 42; //bubbleWidth is a percentage
    public int budgetChange = 0;
    public int pegi = 0;
    public int appealing = 0;

    [XmlArray("Themes")]
    [XmlArrayItem("Theme")]
    public Theme[] themes;

    [XmlArray("Characters")]
    [XmlArrayItem("Character")]
    public Character[] characters;

    [XmlArray("Events")]
    [XmlArrayItem("Event")]
    public Event[] events;

}


public enum Theme
{
    pirate,
    scifi,
    fantasy,
    western,
    historical,
    nature,
    kid,
    postapo,
    romance,
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
