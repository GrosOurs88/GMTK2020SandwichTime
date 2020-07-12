using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostItInstanciationScript : MonoBehaviour
{
    public Image postIt;
    public Sprite[] postItSprite;
    public RectTransform rectTransform;
    public GameObject panelPostIt;
    public float margin;
    private float X;
    private float Y;
    private Vector3 postItPos;
    public RoomController roomController;

    void Start()
    {
        roomController.IdeaSelected += AddPostIt;
    }

    public void AddPostIt(Idea _idea)
    {
        X = Random.Range(
             rectTransform.rect.width * -0.5f + margin,
             rectTransform.rect.width * 0.5f - margin
             );

        Y = Random.Range(
            rectTransform.rect.height * -0.5f + margin,
            rectTransform.rect.height * 0.5f - margin
            );

        Image newPostIt = Instantiate(postIt, panelPostIt.transform);

        newPostIt.transform.localPosition = new Vector3(X, Y, transform.position.z);
        newPostIt.GetComponent<Image>().sprite = postItSprite[_idea.characters[0]];
        newPostIt.transform.Rotate(0f, 0f, Random.Range(0f, 360f));
    }
}
