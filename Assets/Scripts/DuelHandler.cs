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
    public VoidEvent Player_reload;
    public VoidEvent Opponent_reload;
    public Scriptable_object_parent s0;//ai
    public Scriptable_object_parent s1;//human
    

    private void Awake()
    {
        s0 = GameLayout.S.aiCharacter;
        s1= GameLayout.S.playerCharacter;
       
    }
    public void CompareDuel (Card player, Card ai)
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
            //player first then ai
            case("dodgedodge"):
               
            case("hesitatehesitate"):
                
            case("hesitatedodge"):
            case("dodgehesitate"):
                shinshotMiss();
                break;
                //reloads
            case("reloaddhesitate"):
                reloadPlayer();
                shinMiss();
                break;
            case("hesitatereload"):
            reloadAI();
            shotMiss();
            break;
            case ("dodgereload"):
            reloadAI();
            shotMiss();
            break;
            case ("reloaddodge"):
                shinMiss();
            reloadPlayer();
        
            break;
            case ("reloadreload"):
            reloadAI();
            reloadPlayer();
            break;
            case ("reloadaimedShot"):
           
            case ("reloadquickShot"):
            reloadPlayer();
            takeDamagePlayer(s1);
            break;

            case ("quickShotreload"):
            case("aimedShotreload"):
            reloadAI();
            takeDamagePlayer(s0);
            break;
            case ("quickShotaimedShot"):
            shinMiss();
            takeDamagePlayer(s0);
            break;
            case ("aimedShotquickShot"):
            shotMiss();
            takeDamagePlayer(s1);
            break;
            
            case("quickShotdodge"):
            shotMiss();
            break;
            case("aimedShotdodge"):
            takeDamagePlayer(s0);
            break;
            case("dodgequickShot"):
            shinMiss();
            break;
            case("dodgeaimedShot"):
                takeDamagePlayer(s1);
            break;
            case("aimedShotaimedShot"):
            case("quickShotquickShot"):
                takeDamagePlayer();
            break;
        }
        Invoke("waitForPlayer", 4);
    }
    #region event calls
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
    public void shinshotMiss()
    {
        aimiss.FireEvent();
        playermiss.FireEvent();
    }
    public void reloadPlayer()
    {
        Player_reload.FireEvent();
    }
    public void reloadAI()
    {
        Opponent_reload.FireEvent();
    }
    #endregion
    public void waitForPlayer()
    {
        player.state = cardState.toDiscard;
        ai.state = cardState.toDiscard;
    }
}
