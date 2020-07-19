using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxVisibleCharactersSetter : MonoBehaviour
{
    public TMP_Text myText;

    public float ratioOfTextDisplayed = 0f;

    private int characterCount;

    private void Start()
    {
        myText.ForceMeshUpdate();
        characterCount = myText.textInfo.characterCount;
    }

    private void Update()
    {
        myText.maxVisibleCharacters = (int) (characterCount * ratioOfTextDisplayed);
    }

}
