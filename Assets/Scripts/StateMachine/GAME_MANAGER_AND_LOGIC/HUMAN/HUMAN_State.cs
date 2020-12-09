using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUMAN_State : State
{
    #region
    //game enters this state. 
    public new GameState GS; //not using base class field. 
    public HUMAN_State(GameState _GS) : base(_GS)
    {
        GS = _GS;
    }//constructor

    public override IEnumerator Start()
    {
        
        yield break;
    }
    public virtual IEnumerator End()
    {
        yield break;
    }
    #endregion
    
}
public class Waiting_For_Controller_State : HUMAN_State
{
    public Card card;
    public Waiting_For_Controller_State(GameState _GS, Card _card):base(_GS)
    {
        base.GS = _GS;
        card = _card;
    }
    public IEnumerator SendCard()
    {
        //HUMAN_Controller.
    }
    public override IEnumerator Start()
    {
        return base.Start();
    }
    public override IEnumerator End()
        {
        return base.End();
        }


}
public class 
