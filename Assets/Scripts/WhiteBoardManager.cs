using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoardManager : MonoBehaviour
{
    private List<Idea> whiteBoard;

    public void addIdea(Idea idea)
    {
        whiteBoard.Add(idea);
    }
}
