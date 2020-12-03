using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Duel : Card
{
    //These are the fucntions only Duel cards should have
    public enum CardDuelState
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

    [Header("Set Dynamically: CardBartok")]

    public CardDuelState state = CardDuelState.idle;
    public Vector3 handPostion;
    public Vector3 targetPostion;
    public Vector3 discardPostion;

    public void Start()
    {
        state = CardDuelState.toHand;
    }
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case CardDuelState.toDrawpile:
            case CardDuelState.toHand:
                transform.localPosition = handPostion;
                state = CardDuelState.hand;
                break;
            case CardDuelState.toTarget:
                transform.localPosition = targetPostion;
                state = CardDuelState.target;
                break;
            case CardDuelState.toDiscard:
                transform.localPosition = discardPostion;
                state = CardDuelState.discard;
                break;
            
                
            

        }
    }
    public void OnMouseDown()
    {
        state = CardDuelState.toTarget;
    }
}
