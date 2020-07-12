using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Pitch", menuName = "Pitch")]
public class Pitch : ScriptableObject
{
    public string text1;
    public string text2;
    public string text3;

    public float BudgetMin, budgetMax;
    public float AudienceMax;
}
