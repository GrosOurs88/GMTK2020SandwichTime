using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoardManager : MonoBehaviour
{
    private List<Idea> whiteBoard;

    public RoomController roomController;

    public Pitch objective;

    private float budgetBase = 0;
    public void Start()
    {
        whiteBoard = new List<Idea>();

        roomController.IdeaSelected += addIdea;
    }
    public void addIdea(Idea idea)
    {
        whiteBoard.Add(idea);
    }

    public string getResult()
    {
        float budget = budgetBase;
        int pegi = 3;
        float appealing = 0;
        List<Theme> usedThemes = new List<Theme>();

        foreach (Idea idea in whiteBoard)
        {
            budget += idea.budgetChange;

            if (idea.pegi > pegi)
                pegi = idea.pegi;

            appealing += idea.appealing;

            if (idea.themes != null)
            {
                foreach (Theme t in idea.themes)
                {
                    usedThemes.Add(t);
                }
            }
        }

        bool themeCheck = true;

        for (int i = 0; i < objective.themesWanted.Length; i++)
        {
            int count = 0;
            foreach(Theme used_theme in usedThemes)
            {
                if (used_theme == objective.themesWanted[i])
                    count++;
            }

            if (count < objective.themeOccurrence[i])
                themeCheck = false;
        }

        
        string result = null;

        if (budget > objective.budgetMax)
        {
            result += "You've got over budget.\n";
        }
        if (pegi > objective.audienceMax)
        {
            result += "This won't fit our audience.\n";
        }
        if (appealing < objective.appealing)
        {
            result += "It's underwhelming.\n";
        }
        if (!themeCheck)
        {
            result += "Have you forgot the theme?\n";
        }

        return result;
    }

    public string getTitle()
    {
        string[] titles = { "Untitled project", "Your next blockbuster", "Movie\n The movie", "A Palme D'Or Winner", "Future Oscar nominee", "Our great movie"};
        return titles[UnityEngine.Random.Range(0,titles.Length)];
    }

    public int getPegi()
    {
        int pegi = 0;
        foreach (Idea idea in whiteBoard)
        {
            if (idea.pegi > pegi)
                pegi = idea.pegi;
        }

        return pegi;
    }

    public string getMostAppealing()
    {
        string ideaTitle = "nice things";
        float appeal = 0;

        foreach (Idea idea in whiteBoard)
        {
            if (idea.appealing > appeal)
            {
                appeal = idea.appealing;
                ideaTitle = idea.title;
            }
        }

        return ideaTitle;
    }

    public string getRandomIdea()
    {
        string most_appealing = getMostAppealing();
        string least_appealing = getLeastAppealing();
        string ideaTitle = most_appealing;

        if (whiteBoard.Count > 2)
        {
            while (ideaTitle == most_appealing || ideaTitle == least_appealing)
            {
                ideaTitle = whiteBoard[UnityEngine.Random.Range(0, whiteBoard.Count)].title;
            }
        }
        else
        {
            ideaTitle = "some actors";
        }

        return ideaTitle;
    }

    public string getLeastAppealing()
    {
        string ideaTitle = "yeah, that's all";
        float appeal = float.MaxValue;

        foreach (Idea idea in whiteBoard)
        {
            if (idea.appealing < appeal)
            {
                appeal = idea.appealing;
                ideaTitle = idea.title;
            }
        }

        return ideaTitle;
    }

    public float getBudget()
    {
        float total = budgetBase;

        foreach(Idea i in whiteBoard)
        {
            total += i.budgetChange;
        }

        if (total < 1)
        {
            total = 1;
        }

        return total;
    }


    public void endInfos()
    {
        Debug.Log("-------- ENDING INFOS --------");

        Debug.Log("number of selected ideas " + whiteBoard.Count);

        Debug.Log("Unedited budget is " + getBudget());

        float appealing = 0;
        foreach(Idea i in whiteBoard)
        {
            appealing += i.appealing;
        }

        Debug.Log("Sum of appealing " + appealing);

            foreach (Theme t in Enum.GetValues(typeof(Theme)))
        {
            int occurence = 0;

            foreach (Idea i in whiteBoard)
            {
                if (i.themes != null)
                {
                    foreach (Theme t2 in i.themes)
                    {
                        if (t2 == t)
                            occurence++;
                    }
                }
            }


            Debug.Log("occurences of " + t + " = " + occurence);
        }


    }
}
