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
    public Deck deck;

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
    public void Update()
    {
        switch (state)
        {
            // animate to hand
            case cardState.toHand:
                transform.position = GameObject.Find("Player_Hand").transform.position;
                state = cardState.hand;
                break;
            // animate to target
            case cardState.toTarget:
                transform.position = GameObject.Find("Player_Target").transform.position;
                state = cardState.target;
                break;
            // animate to discard pile
            case cardState.toDiscard:
                transform.position = GameObject.Find("Player_DiscardPile").transform.position;
                state = cardState.discard;
                break;
            case cardState.to:
                break;
            // do nothing for these
            case cardState.hand:
            case cardState.target:
            case cardState.discard:
            case cardState.drawpile:
            case cardState.idle:
                break;
        }

    }
    public void OnMouseDown()
    {
        switch(state)
        {
            // only clicking cards in your hand will play them
            case cardState.hand:
                transform.position = GameObject.Find("Player_Target").transform.position;
                break;
            case cardState.target:
            case cardState.discard:
            case cardState.drawpile:
                break;
        }
    }
}
