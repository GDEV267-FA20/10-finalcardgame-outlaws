using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTest : State
{


    public StateTest(GameState gameState) : base(gameState)
    {
        GS = gameState;
    }
    public override IEnumerator Start()
    {
        Debug.Log("hello i am state test start");
        yield break;
    }
    public override IEnumerator hello()
    {
        GS.SetState(new AlsoStateTest((GS)));
        yield break;
          
    }
}
public class AlsoStateTest: State
{
  

    public AlsoStateTest(GameState gameState) : base(gameState)
    {
       GS = gameState;
    }

    public override IEnumerator Start()
    {
        Debug.Log("i am also state test start");
        yield break;
    }
    public override IEnumerator hello()
    {
        GS.SetState(new StateTest((GS)));
        yield break;

    }
}
