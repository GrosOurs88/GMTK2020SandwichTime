using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    public float timeToLive = 1f;
    public float speed = 100f;
    public Image image;
    public CanvasGroup canvasGroup;

    private float timeAlive;

    void Update()
    {
        timeAlive += Time.deltaTime;

        canvasGroup.alpha = 1- (timeAlive / timeToLive);
        transform.position += Vector3.up * Time.deltaTime * speed;

        if (timeAlive >= timeToLive)
        {
            Destroy(gameObject);
        }
    }
}
