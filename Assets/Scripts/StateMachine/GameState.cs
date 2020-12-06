﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState : MonoBehaviour
{
    protected State _state;

    public virtual void SetState(State state)
    {
        _state = state;
        StartCoroutine(_state.Start());
    }
}
