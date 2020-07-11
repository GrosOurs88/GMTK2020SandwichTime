using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject bubblesContainer;
    public GameObject bubblePrefab;

    public void DisplayIdeaBubble (Idea idea)
    {
        Bubble bubble = Instantiate(bubblePrefab, this.transform).GetComponent<Bubble>();

        bubble.Setup(idea);
        //TODO set random position
    }

}
