﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MasterButtonScript : MonoBehaviour
{
    public Canvas canvasMainMenu;
    public Canvas canvasObjectifs;
    public Canvas canvasWhiteboard;
    public Canvas canvasRoom;
    public Canvas canvasFinish;
    public Image canvasObjectifsBackground;
    public Image canvasWhiteboardBackground;
    public Image canvasRoomBackground;
    public Image panelBlackscreenBackground;
    public float transitionTimeToObjectifCanvas;
    public float transitionTimeToGameCanvas;
    public float transitionTimeToPitchCanvas;
    public GameObject panelTitle;
    public GameObject panelPitchTitle_Pegi;
    public GameObject panelPitchMoments;
    public GameObject panelPitchBudgets;
    public GameObject panelPitchNotation;
    public Button buttonRestart;
    public Image image1;
    public Image image2;
    public Image image3;
    public Button startButton;

    public BrainstormManager brainstormManager;
    public WhiteBoardManager whiteBoardManager;

    public List<Sprite> pegi = new List<Sprite>();
    public Sprite happyFace;
    public Sprite unHaappyFace;

    public TextMeshProUGUI gameTitle;
    public Image gamePegi;
    public TextMeshProUGUI memorableMoments;
    public TextMeshProUGUI budget;
    public Image notation;


    //Singleton
    public static MasterButtonScript instance;

    void Awake()
    {
        //***SINGLETON***
        instance = this;
    }

    private void Start()
    {
        brainstormManager = GameObject.Find("BrainstormManager").GetComponent<BrainstormManager>();

        image1.transform.GetComponentInChildren<TextMeshProUGUI>().text = brainstormManager.selectedPitch.text1;
        image2.transform.GetComponentInChildren<TextMeshProUGUI>().text = brainstormManager.selectedPitch.text2;
        image3.transform.GetComponentInChildren<TextMeshProUGUI>().text = brainstormManager.selectedPitch.text3;
    }

    private void Update()
    {
       
    }

    public void TransitionToObjectivesCanvas()
    {
        MasterSoundsScript.instance.PlayButtonClic();
        StartCoroutine("TransitionObjectivesCanvas");
    }

    public void TransitionToGameCanvas()
    {
        MasterSoundsScript.instance.PlayButtonClic();
        StartCoroutine("TransitionGameCanvas");
    }

    public void TransitionToPitchCanvas()
    {
        MasterSoundsScript.instance.PlayButtonClic();
        StartCoroutine("TransitionPitchCanvas");
    }

    public void TransitionToMeetingEnd()
    {
        MasterSoundsScript.instance.PlayButtonClic();
        canvasFinish.gameObject.SetActive(true);
        MasterSoundsScript.instance.PlayMeetingEnd();
        MasterSoundsScript.instance.PlayMeetingEndMusic();

        whiteBoardManager.endInfos();
    }

    public IEnumerator TransitionPitchCanvas()
    {
        var tempColor = panelBlackscreenBackground.color;
        tempColor.a = 0f;
        panelBlackscreenBackground.color = tempColor;

        panelBlackscreenBackground.gameObject.SetActive(true);
        yield return null;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / transitionTimeToPitchCanvas)
        {
            Color newColor = new Color(panelBlackscreenBackground.color.r, panelBlackscreenBackground.color.g, panelBlackscreenBackground.color.b, Mathf.Lerp(0f, 1f, t));
            panelBlackscreenBackground.color = newColor;
            yield return null;
        }

         //FILL Empty INfos
         gameTitle.text = whiteBoardManager.getTitle();

        switch (whiteBoardManager.getPegi())
        {
            case 3:
                gamePegi.sprite = pegi[0];
                break;
            case 7:
                gamePegi.sprite = pegi[1];
                break;
            case 10:
                gamePegi.sprite = pegi[2];
                break;
            case 12:
                gamePegi.sprite = pegi[3];
                break;
            case 16:
                gamePegi.sprite = pegi[4];
                break;
            case 18:
                gamePegi.sprite = pegi[5];
                break;

        }

        memorableMoments.text = "So our game is going to feature a " + whiteBoardManager.getMostAppealing() + " and a ... " + whiteBoardManager.getLeastAppealing();

        budget.text = (whiteBoardManager.getBudget() * 312745).ToString() + " $";

        if(whiteBoardManager.getResult())
        {
            notation.sprite = happyFace; // gagné :)
        }
        else
        {
            notation.sprite = unHaappyFace; // perdu :(
        }
        //FILL Empty INfos


        canvasWhiteboard.gameObject.SetActive(false);
        canvasRoom.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        panelPitchTitle_Pegi.gameObject.SetActive(true);
        yield return new WaitForSeconds(7f);
        panelPitchTitle_Pegi.gameObject.SetActive(false);

        panelPitchMoments.gameObject.SetActive(true);
        yield return new WaitForSeconds(7f);
        panelPitchMoments.gameObject.SetActive(false);

        panelPitchBudgets.gameObject.SetActive(true);
        yield return new WaitForSeconds(7f);
        panelPitchBudgets.gameObject.SetActive(false);

        panelPitchNotation.gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);
        panelPitchNotation.gameObject.SetActive(false);

        buttonRestart.gameObject.SetActive(true);
        yield return null;
    }



    public IEnumerator TransitionObjectivesCanvas()
    {
        var tempColor = canvasObjectifsBackground.color;
        tempColor.a = 0f;
        canvasObjectifsBackground.color = tempColor;

        canvasObjectifs.gameObject.SetActive(true);        
        yield return null;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / transitionTimeToObjectifCanvas)
        {
            Color newColor = new Color(canvasObjectifsBackground.color.r, canvasObjectifsBackground.color.g, canvasObjectifsBackground.color.b, Mathf.Lerp(0f, 1f, t));
            canvasObjectifsBackground.color = newColor;
            yield return null;
        }

        canvasMainMenu.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        panelTitle.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        image1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        image2.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        image3.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        startButton.interactable = true;
        yield return null;
    }

    public IEnumerator TransitionGameCanvas()
    {
        brainstormManager.startBrainstorm();

        var tempColor = canvasWhiteboardBackground.color;
        var tempColor2 = canvasRoomBackground.color;
        tempColor.a = 0f;
        tempColor2.a = 0f;
        canvasWhiteboardBackground.color = tempColor;
        canvasRoomBackground.color = tempColor2;

        canvasRoom.gameObject.SetActive(true);
        canvasWhiteboard.gameObject.SetActive(true);
        canvasObjectifs.gameObject.SetActive(false);
        yield return null;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / transitionTimeToGameCanvas)
        {
            Color newColor = new Color(canvasWhiteboardBackground.color.r, canvasWhiteboardBackground.color.g, canvasWhiteboardBackground.color.b, Mathf.Lerp(0f, 1f, t));
            Color newColor1 = new Color(canvasRoomBackground.color.r, canvasRoomBackground.color.g, canvasRoomBackground.color.b, Mathf.Lerp(0f, 1f, t));
            canvasWhiteboardBackground.color = newColor;
            canvasRoomBackground.color = newColor1;

            yield return null;
        }

        MasterSoundsScript.instance.PlayMainlMusic();
        yield return null;
    }
}
