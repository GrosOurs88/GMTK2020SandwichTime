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
        ;
    }
}
