using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoardManager : MonoBehaviour
{
    private List<Idea> whiteBoard;

    public RoomController roomController;

    public Pitch objective;
    public void Start()
    {
        whiteBoard = new List<Idea>();

        roomController.IdeaSelected += addIdea;
    }
    public void addIdea(Idea idea)
    {
        whiteBoard.Add(idea);
    }

    public bool getResult()
    {
        float budget = 0;
        int pegi = 3;
        float appealing = 0;
        List<Theme> usedThemes = new List<Theme>();
        //List<int> themeOccurrence = new List<int>();

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


            //foreach(Theme t in idea.themes)
            //{
            //    int themeIndex = usedThemes.IndexOf(t);

            //    if(themeIndex < 0)
            //    {
            //        usedThemes.Add(t);
            //        themeOccurrence.Add(1);
            //    }
            //    else
            //    {
            //        themeOccurrence[themeIndex]++;
            //    }
            //}

        }

        bool themeCheck = true;

        for (int i = 0; i < objective.themesWanted.Length; i++)
        {
            int count = 0;
            foreach(Theme t2 in usedThemes)
            {
                if (t2 == objective.themesWanted[i])
                    count++;
            }

            if (count < objective.themeOccurrence[i])
                themeCheck = false;
        }

        //for(int i = 0; i < objective.themesWanted.Length; i++ )
        //{
        //    if(usedThemes.IndexOf(objective.themesWanted[i]) < 0)
        //    {
        //        themeCheck = false;
        //    }
        //    else if( themeOccurrence[usedThemes.IndexOf(objective.themesWanted[i])] < objective.themeOccurrence[i])
        //    {
        //        themeCheck = false;
        //    }
        //}

        
        return budget <= objective.budgetMax && pegi <= objective.audienceMax && appealing >= objective.appealing && themeCheck;
    }

    public string getTitle()
    {
        return null;
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
        string ideaTitle = whiteBoard[0].title;
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

    public string getSecondMostAppealing()
    {
        return null;
    }

    public string getLeastAppealing()
    {
        string ideaTitle = whiteBoard[0].title;
        float appeal = 999999999999;

        foreach (Idea idea in whiteBoard)
        {
            if (appeal < idea.appealing )
            {
                appeal = idea.appealing;
                ideaTitle = idea.title;
            }
        }

        return ideaTitle;
    }

    public float getBudget()
    {
        float total = 0;

        foreach(Idea i in whiteBoard)
        {
            total += i.budgetChange;
        }

        return total;
    }
}
