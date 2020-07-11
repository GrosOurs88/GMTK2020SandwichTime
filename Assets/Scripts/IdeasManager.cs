using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeasManager : MonoBehaviour
{
    public string ideaXMLPath;


    private IdeaContainer ideaContainer;


    void Awake()
    {
        ideaContainer = IdeaContainer.Load(ideaXMLPath);

        //create idea list
    }

}
