using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Copperplate", menuName = "Create Instance of Copperplate", order =3)]
public class Copperplate : Scriptable_object_parent
{
    public override void UndoChange()
    {
        //run this at the end of the game. reset all the stats to normal. 
        health = 3;
        confidence = 3;
        accuracy = 3;
        reaction = 2;
        money = 3;
    }

}
