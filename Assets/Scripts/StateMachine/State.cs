using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State  
{
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
