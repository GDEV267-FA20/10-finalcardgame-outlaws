using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum cardState
{
    toDrawpile,

    drawpile,

    toHand,

    hand,

    toTarget,

    target,

    toDiscard,

    discard,

    to,

    idle
}

public class Card : MonoBehaviour
{
    public string type;
    public bool faceUp;
    public cardState state;

    public void setFace(bool newfaceUp)
    {
        this.faceUp = newfaceUp;
    }
    public bool getFace()
    {
        return faceUp;
    }
    public string getType()
    {
        return type;
    }
    public void setType(int Num)
    {
        string newType;
        switch (Num)
        {
            default:
                newType = "aimedShot";
                break;
            case 1:
                newType = "quickShot";
                break;
            case 2:
                newType = "hesitate";
                break;
            case 3:
                newType = "dodge";
                break;

        }
        this.type = newType;
    }
    /*public void Update()
    {
        switch (state)
        {

            case cardState.toHand:

            case cardState.toTarget:

            case cardState.toDrawpile:

            case cardState.to:
        }





    }*/
}
