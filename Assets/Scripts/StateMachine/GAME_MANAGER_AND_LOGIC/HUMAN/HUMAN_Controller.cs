using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ships.events;

public class HUMAN_Controller : GameState
{
    public CardEvent cardEvent;
    
    public new State _state;
    private void Start()
    {
        
    }
    public override void SetState(State state)
    {
        _state = state;
        StartCoroutine(_state.Start());
    }
    //public void 
}
