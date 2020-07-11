using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    public Idea myIdea;
    public RoomController roomController;

    public TMP_Text text;
    public CanvasGroup canvasGroup;
    public float fadeOutTime;

    public RectTransform rectTransform;

    public void Setup(Idea idea, RoomController room_controller)
    {
        roomController = room_controller;
        myIdea = idea;
        text.text = idea.text;
    }

    public void Kill()
    {
        Destroy(gameObject, fadeOutTime + 1f);
        StartCoroutine("FadeOutAndDie");
    }

    IEnumerator FadeOutAndDie()
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeOutTime)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t);
            yield return null;
        }
    }

    public void OnButtonClicked()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            OnDiscarded();
        }
        else
        {
            OnSelected();
        }
    }

    public void OnSelected()
    {
        roomController.SelectIdeaBubble(myIdea, this);
        Destroy(gameObject);
    }
    public void OnDiscarded()
    {
        roomController.DiscardIdeaBubble(myIdea, this);
        Destroy(gameObject);
    }
}
