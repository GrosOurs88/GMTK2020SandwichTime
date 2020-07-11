using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    public TMP_Text text;
    public Image characterImage;
    public Image bubbleBackground;
    public CanvasGroup canvasGroup;

    public void Kill()
    {
        //TODO coroutine alpha to 0 then destroy
    }
}
