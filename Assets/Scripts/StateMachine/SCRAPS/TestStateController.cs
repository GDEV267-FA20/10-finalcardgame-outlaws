using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStateController : GameState
{
    private void Start()
    {
        base.SetState(new StateTest(this));
    }
    public override void SetState(State state)
    {
        _state = state;
        StartCoroutine(_state.Start());
    }
    public void changeState()
    {
       
        StartCoroutine(_state.hello());
        
    }
    
}
