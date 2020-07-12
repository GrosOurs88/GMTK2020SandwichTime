using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    public float timeToLive = 1f;
    public Image image;
    public CanvasGroup canvasGroup;

    private float timeAlive;

    void Update()
    {
        timeAlive += Time.deltaTime;

        canvasGroup.alpha = 1- (timeAlive / timeToLive); 

        if (timeAlive >= timeToLive)
        {
            Destroy(gameObject);
        }
    }
}
