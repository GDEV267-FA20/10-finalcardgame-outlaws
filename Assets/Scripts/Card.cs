﻿using System.Collections;
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
    

    public bool moving;
    public bool ai;

    public float timeStartedLerping;
    public float lerpTime;

    public Vector2 endPosition;
    public Vector2 startPosition;
    public Vector3 duel_target_layout;
    public Vector3 duel_GY_position;
    

    public static GameObject Player_Hand;
    public static GameObject Player_Target;
    public  static GameObject Player_DiscardPile;

    private void Awake()
    {
        Player_Hand = GameObject.Find("Player_Hand");
        Player_Target = GameObject.Find("Player_Target");
        Player_DiscardPile = GameObject.Find("Player_DiscardPile");

    }

    public bool ReachedCenter
    {
        get {
            if(gameObject.transform.position - duel_target_layout == Vector3.zero)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
    public bool ReachedGY
    {
        get {
            if(gameObject.transform.position - duel_GY_position == Vector3.zero)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
    #region setters and getters
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
                newType = "dodge";
                break;
            case 3:
                newType = "hesitate";
                break;

        }
        this.type = newType;
    }
    #endregion
    public void Update()
    {
        switch (state)
        {
            // animate to hand
            case cardState.toHand:
                transform.position = Lerp( transform.position, Player_Hand.transform.position, Time.time);
                state = cardState.hand;
                break;
            // animate to target
            case cardState.toTarget:
                transform.position =Lerp(transform.position, Player_Target.transform.position, Time.time);
                if(!moving){ state = cardState.target; }
                
                break;
            // animate to discard pile
            case cardState.toDiscard:
                transform.position = Lerp(transform.position, Player_DiscardPile.transform.position, Time.time);
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
                //transform.position = GameObject.Find("Player_Target").transform.position;
                Debug.Log("was clicked");
                moving = true;
                state= cardState.toTarget;
                break;
            case cardState.target:
            case cardState.discard:
            case cardState.drawpile:
                break;
        }
    }
    public Vector3 Lerp(Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime = 1)
    {

        float timeSinceStarted = Time.time - timeStartedLerping;

        float percentageComplete = timeSinceStarted / lerpTime;

        var result = Vector3.Lerp(start, end, percentageComplete*Time.deltaTime);

        // value hits 1 we finished moving so we need to stop lerping
        if (percentageComplete >= 1)
        {

            Debug.Log("Finished Lerp...");
            moving = false;
        }

        return result;
    }
    /*public IEnumerator animateCardBecauseItWasPlayed()
    {
        try
        {
            while (!ReachedCenter)
            {
                //animate card to that position
                endPosition = GameObject.Find("Player_Target").transform.position;
                transform.position = Lerp(startPosition, endPosition, timeStartedLerping, lerpTime);
            }
            yield break;

        }
        finally
        {
            StartCoroutine(MoveOffScreen());
        }
    }

    private IEnumerator MoveOffScreen()
    {
        try
        {
            while (!ReachedGY)
            {
                //animate card to that position
                endPosition = GameObject.Find("Player_DiscardPile").transform.position;
                transform.position = Lerp(startPosition, endPosition, timeStartedLerping, lerpTime);
            }
            yield break;
        }
        finally
        {
            // play sound effect?
        }
    }*/
}
