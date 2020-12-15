using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ships.events;

public class DuelHandler : MonoBehaviour
{
    public Card ai;
    public Card player;
    public VoidEvent aiDamage;
    public VoidEvent playerDamage;
    public VoidEvent playermiss;
    public VoidEvent aimiss;
    public Scriptable_object_parent s0;
    public Scriptable_object_parent s1;
    

    private void Awake()
    {
        s0 = GameLayout.S.aiCharacter;
        s1= GameLayout.S.playerCharacter;
       
    }
    public void CompareDuel (Card ai, Card player)
    {
        var aiType = ai.type;
        var playerType = player.type;
        var test = aiType+playerType;
        /*if(aiType == playerType)
        {
            if((aiType=="aimedShot")||(aiType == "quickShot")){
                takeDamagePlayer();

            }
            else if ((aiType == "dodge")||(aiType == "hesitate"))
            {
                shotMiss();
                shinMiss();
            }
        }else if((aiType == "aimedShot")&&(playerType == "quickShot"))
        {
            if 
        }*/
        switch(test)
        {
            case("dodgedodge"):
               
            case("hesitatehesitate"):
                
            case("hesitatedodge"):
            case("dodgehesitate"):
                //reloads
            case("reloaddhesitate"):
            case("hesitatereload"):
            case("dodgereload"):
            case("reloaddodge"):
            
            case("reloadreload"):

            case("reloadaimedShot"):
            case ("reloadquickShot"):
            case("quickShotreload"):
            case("aimedShotreload"):
            
            case("quickShotaimedShot"):
            case("aimedShotquickShot"):
            case("quickShotdodge"):
            case("aimedShotdodge"):
            case("dodgequickShot"):
            case("dodgeaimedShot"):
            case("aimedShotaimedShot"):
            case("quickShotquickShot"):

        }
    }
    public void takeDamagePlayer(Scriptable_object_parent s_)
    {
        s_.temphealth -= 1;
        if(s0.ai == 1)
        {
            aiDamage.FireEvent();
        }
        if(s0.human == 1)
        {
            playerDamage.FireEvent();
        }

    }
    public void takeDamagePlayer()
    {
        s0.temphealth -=1;
        
        s1.temphealth -=1;
        playerDamage.FireEvent();
        aiDamage.FireEvent();
    }
    public void shotMiss()
    {
        playermiss.FireEvent();
    }
    public void shinMiss()
    {
        aimiss.FireEvent();
    }

}
