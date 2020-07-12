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
        List<int> themeOccurrence = new List<int>();

        foreach (Idea idea in whiteBoard)
        {
            budget += idea.budgetChange;

            if (idea.pegi > pegi)
                pegi = idea.pegi;

            appealing += idea.appealing;

            foreach(Theme t in idea.themes)
            {
                int themeIndex = usedThemes.IndexOf(t);

                if(themeIndex < 0)
                {
                    usedThemes.Add(t);
                    themeOccurrence.Add(1);
                }
                else
                {
                    themeOccurrence[themeIndex]++;
                }
            }
            
        }

        bool themeCheck = true;

        for(int i = 0; i < objective.themesWanted.Length; i++ )
        {
            if(usedThemes.IndexOf(objective.themesWanted[i]) < 0)
            {
                themeCheck = false;
            }
            else if( themeOccurrence[usedThemes.IndexOf(objective.themesWanted[i])] < objective.themeOccurrence[i])
            {
                themeCheck = false;
            }
        }

        for (int i = 0; i < objective.themesWanted.Length; i++)
        {
            Debug.Log("wanted theme " + objective.themesWanted[i] + "  occurence " + objective.themeOccurrence[i]);
        }

        for (int i = 0; i <usedThemes.Count; i++)
        {
            Debug.Log("used theme " + usedThemes[i] + "  occurence " + themeOccurrence[i]);
        }
        
        return budget <= objective.budgetMax && pegi <= objective.audienceMax && appealing >= objective.appealing && themeCheck;
    }
}
