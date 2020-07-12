using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MasterButtonScript : MonoBehaviour
{
    public Canvas canvasMainMenu;
    public Canvas canvasObjectifs;
    public Image canvasObjectifsBackground;
    public float transitionTime;
    private Image objectifBackground;
    public GameObject panelTitle;
    public Image image1;
    public Image image2;
    public Image image3;
    public Button startButton;
    public BrainstormManager brainstormManager;

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

    public void TransitionToObjectivesCanvas()
    {
        StartCoroutine("TransitionObjectivesCanvas");
    }

    public IEnumerator TransitionObjectivesCanvas()
    {
        objectifBackground = canvasObjectifsBackground.GetComponent<Image>();
        var tempColor = objectifBackground.color;
        tempColor.a = 0f;
        objectifBackground.color = tempColor;

        canvasObjectifs.gameObject.SetActive(true);        
        yield return null;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / transitionTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(0f, 1f, t));
            objectifBackground.color = newColor;
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



        /*
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / transitionTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(0f, 1f, t));
            image1.color = newColor;
            image2.color = newColor;
            image3.color = newColor;
            yield return null;
        }
        */




        yield return null;
    }
}
