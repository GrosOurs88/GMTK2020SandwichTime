using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public RectTransform bubblesContainer;
    public GameObject[] bubblePrefabs;

    public float bubblesHeightMargin = 30f;

    public Bubble first_bubble;

    public void DisplayIdeaBubble (Idea idea)
    {
        int character = idea.characters[Random.Range(0, idea.characters.Length)];
        Bubble bubble = Instantiate(bubblePrefabs[character], bubblesContainer).GetComponent<Bubble>();

        bubble.Setup(idea);

        float randomized_height = Random.Range(
            bubblesContainer.rect.height * -0.5f + bubblesHeightMargin,
            bubblesContainer.rect.height * 0.5f - bubblesHeightMargin - bubble.rectTransform.rect.height
            );

        bubble.rectTransform.localPosition = new Vector3(bubble.rectTransform.localPosition.x, randomized_height, bubble.rectTransform.localPosition.z);

    }


}
