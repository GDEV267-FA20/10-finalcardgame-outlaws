using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    quickShot, //0
    hesitate, //1
    aimedShot, //2
    dodge, //3
}
public class CardOutlaws : Card
{
    
    public CardType eCardType;
    
    // pass in the index of the card type here 0-3
    public void setCardType(int index)
    {
        switch(index)
        {
            case 0:
                eCardType = CardType.quickShot;
                break;
            case 1:
                eCardType = CardType.hesitate;
                break;
            case 2:
                eCardType = CardType.aimedShot;
                break;
            case 3:
                eCardType = CardType.dodge;
                break;
        }
    }
    // returns cardtype
    public CardType getCardType()
    {
        return eCardType;
    }

   
}
