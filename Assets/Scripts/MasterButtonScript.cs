using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterButtonScript : MonoBehaviour
{
    public Canvas canvasMainMenu;
    public Canvas canvasObjectifs;


    //Singleton
    public static MasterButtonScript instance;

    void Awake()
    {
        //***SINGLETON***
        instance = this;
    }

    public void TransitionToObjectivesCanvas()
    {

    }





}
