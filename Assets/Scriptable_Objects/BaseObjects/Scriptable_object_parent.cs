using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scriptable_object_parent : ScriptableObject
{
    
    public int health;
    public int temphealth;
    public int confidence;
    public int accuracy;
    public int reaction;
    public int money;
    public int human; //1 if true 0 if fallse
    public int ai; //1 if true 0 if fallse


    public int _Health{get{return(health);}set{health=value;}}
    public int _Confidence { get { return (confidence); } set { confidence=value; } }
    public int _Accuracy { get { return (accuracy); } set { accuracy=value; } }
    public int _Reaction { get { return (reaction); } set { reaction=value; } }
    public int _Money{get{return(money);} set{money = value;} }

    public virtual void Special_Effect(Scriptable_object_parent opponent)
    {
        return;
    }

    public virtual void ClickedByHuman()
    {
        human = 1;
    }

    public virtual void UndoChange()
    {
        //run this at the end of the game. reset all the stats to normal. 
    }
}
