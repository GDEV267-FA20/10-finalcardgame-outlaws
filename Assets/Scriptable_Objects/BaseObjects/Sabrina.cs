using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Sabrina", menuName = "Create Instance of Sabrina", order =1)]
public class Sabrina : Scriptable_object_parent
{
    public override void UndoChange()
    {
        //run this at the end of the game. reset all the stats to normal.
        health = 3;
        confidence = 3;
        accuracy = 3;
        reaction = 3;
        money = 0;
    }

    public override void Special_Effect(Scriptable_object_parent opponent)
    {
        opponent._Reaction -= 1;
    }


}
