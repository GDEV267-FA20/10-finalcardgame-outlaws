using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State  
{
    protected GameState GS;
    
    public State(GameState gameState)
    {
        GS=gameState;
    }//you need to implement the constructor in your impmeentations!
    public virtual IEnumerator Start()
    {
        yield break;
    }
    public virtual IEnumerator ReadyForUpdate()
    {
        yield break;
    }
    public virtual IEnumerator WaitingForInput()
    {
        yield break;
    }
}
