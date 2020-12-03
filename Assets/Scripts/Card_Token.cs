using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Token : Card
{
    //These are the fucntions only Token cards should have
    public enum CardTokenState
    {
        toDrawpile,

        drawpile,

        toHand,

        hand,

        toTarget,

        target,

        discard,

        to,

        idle
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
