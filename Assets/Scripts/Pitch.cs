using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Pitch", menuName = "Pitch")]
public class Pitch : ScriptableObject
{
    public string text1;
    public string text2;
    public string text3;

    public float budgetMax;
    public float audienceMax;
    public float appealing;

    public Theme[] themesWanted;
    public int[] themeOccurrence;
}

