using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//These are the fucntions only Location cards should have
public enum CardLocationState
{
    // not gonna have any states here
    // no animations always just sitting there waiting to be clicked
}

public class Card_Location : MonoBehaviour
{
    [Header("Set in Inspector")]

    public int moneyChange;
    public int hpChange;
    public int accuracyChange;
    public int reactionTimeChange;
    public int confidenceChange;

    public  void OnMouseDown()
    {
        // change stats based on where clicked
        // playerStats += change
        Debug.Log("yo");
        
    }
}
