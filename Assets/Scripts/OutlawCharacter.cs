using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlawCharacter : MonoBehaviour {

    private int health;
    private int money;
    private int reaction;
    private int confidence;
    private int accuracy;
    private bool human;
    private Scriptable_object_parent character;

    public OutlawCharacter() {
        health = 4;
        money = 0;
        reaction = 3;
        confidence = 3;
        accuracy = 3;
        human = false;
    }

    public OutlawCharacter(bool hum) {
        health = 4;
        money = 0;
        reaction = 3;
        confidence = 3;
        accuracy = 3;
        human = hum;
    }

    public OutlawCharacter(int hp, int mon, int rea, int con, int acc, bool hum) {
        health = hp;
        money = mon;
        reaction = rea;
        confidence = con;
        accuracy = acc;
        human = hum;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    //pushes the information to the scriptable object, which persists between each scene
    public void pushInfo() {
        character._Health = health;
        character._Confidence = confidence;
        character._Accuracy = accuracy;
        character._Reaction = reaction;
        character._Money = money;
    }

}
