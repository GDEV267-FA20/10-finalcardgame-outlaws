using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scriptable_object_parent : ScriptableObject
{
    public int health;
    public int confidence;
    public int accuracy;
    public int reaction;
    public int money;

    public int _Health{get{return(health);}set{health=value;}}
    public int _Confidence { get { return (confidence); } set { confidence=value; } }
    public int _Accuracy { get { return (accuracy); } set { accuracy=value; } }
    public int _Reaction { get { return (reaction); } set { reaction=value; } }
    public int _Money{get{return(money);} set{money = value;} }

}
