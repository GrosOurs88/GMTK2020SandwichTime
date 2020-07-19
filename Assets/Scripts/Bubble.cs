using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Bubble : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Idea myIdea;
    public RoomController roomController;
    public Animator myAnimator;

    public TMP_Text text;
    public CanvasGroup canvasGroup;
    public RectTransform bubbleGroup;
    public float fadeOutTime;

    public RectTransform rectTransform;

    public Character name;

    private bool isBeingMoved;
    private Vector3 moveMouseStartPosition;
    private Vector3 moveBubbleStartPosition;
    private Vector3 moveBubbleOffsetWithMouse;

    public void Setup(Idea idea, RoomController room_controller)
    {
        roomController = room_controller;
        myIdea = idea;
        text.text = idea.text;

        switch(name)
        {
            case Character.Chantal:
            {
                    MasterSoundsScript.instance.PlayCharacter1Blabla();
            }
            break;

            case Character.Surfer:
                {
                    MasterSoundsScript.instance.PlayCharacter2Blabla();
                }
                break;
            case Character.Token:
                {
                    MasterSoundsScript.instance.PlayCharacter3Blabla();
                }
                break;
            case Character.Fabrice:
                {
                    MasterSoundsScript.instance.PlayCharacter4Blabla();
                }
                break;
            case Character.Boss:
                {
                    MasterSoundsScript.instance.PlayCharacter5Blabla();
                }
                break;
            case Character.Woman:
                {
                    MasterSoundsScript.instance.PlayCharacter6Blabla();
                }
                break;
            case Character.Gay:
                {
                    MasterSoundsScript.instance.PlayCharacter7Blabla();
                }
                break;


        }
    }

    public void Kill()
    {
        Destroy(gameObject, fadeOutTime + 1f);
        StartCoroutine("FadeOutAndDie", Vector3.zero);
    }

    IEnumerator FadeOutAndDie(Vector3 direction)
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeOutTime)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t);
            bubbleGroup.position += direction * Time.deltaTime * 6000f;
            yield return null;
        }
    }
    
    public void OnPointerEnter(PointerEventData pointerEventData)
    {

    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isBeingMoved = true;
            moveMouseStartPosition = Input.mousePosition;
            moveBubbleStartPosition = bubbleGroup.position;
            moveBubbleOffsetWithMouse = moveBubbleStartPosition - moveMouseStartPosition;
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            //
        }
    }

    public void SelectIdea()
    {
        roomController.SelectIdeaBubble(myIdea, this);
        Destroy(gameObject, fadeOutTime + 1f);
        StartCoroutine("FadeOutAndDie", Vector3.up);
    }
    public void DiscardIdea()
    {
        DiscardIdea(Vector3.zero);
    }
    public void DiscardIdea(Vector3 exit_direction)
    {
        roomController.DiscardIdeaBubble(myIdea, this);
        Destroy(gameObject, fadeOutTime + 1f);
        StartCoroutine("FadeOutAndDie", exit_direction);
    }

    public void DeactivateAnimator()
    {
        myAnimator.enabled = false;
    }

    private void Update()
    {
        if (isBeingMoved)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                isBeingMoved = false;

                DetermineBubbleMovement();
            }
            else
            {
                bubbleGroup.position = Input.mousePosition + moveBubbleOffsetWithMouse;
            }
        }
    }

    private void DetermineBubbleMovement()
    {
        Vector3 mouse_movement = Input.mousePosition - moveMouseStartPosition;

        if (mouse_movement.magnitude < rectTransform.rect.width * 0.08f)
        {
            bubbleGroup.position = moveBubbleStartPosition;
            return;
        }

        float angle = Vector3.SignedAngle(Vector3.up, mouse_movement, Vector3.forward);
        
        if (Mathf.Abs(angle) < 45f) //up
        {
            SelectIdea();
        }
        else if (Mathf.Abs(angle) < 135f && mouse_movement.x > 0f) //right
        {
            DiscardIdea(mouse_movement.normalized);
        }
        else if (Mathf.Abs(angle) < 135f && mouse_movement.x < 0f) //left
        {
            DiscardIdea(mouse_movement.normalized);
        }
        else //bottom
        {
            DiscardIdea(mouse_movement.normalized);
        }
    }

    private void OnDrawGizmos()
    {
        if (isBeingMoved)
        {
            Gizmos.DrawRay(moveMouseStartPosition, Input.mousePosition - moveMouseStartPosition);
        }
    }

}
