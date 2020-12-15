using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOutlaw : MonoBehaviour{
    
    private int health;
    private int money;
    private int reaction;
    private int confidence;
    private int accuracy;
    private bool human;
    private Scriptable_object_parent character;

    //private void Awake() {
    //    setStats();
    //}

    public void setStats() {
        health = 4;
        money = 0;
        reaction = 3;
        confidence = 3;
        accuracy = 3;
        human = false;
    }

    public void setStats(bool hum) {
        health = 4;
        money = 0;
        reaction = 3;
        confidence = 3;
        accuracy = 3;
        human = hum;
    }

    public void setStats(Scriptable_object_parent cowboy, bool hum) {
        health = cowboy.health;
        money = cowboy.money;
        reaction = cowboy.reaction;
        confidence = cowboy.confidence;
        accuracy = cowboy.accuracy;
        human = hum;
        character = cowboy;
    }

    public void setStats(int hp, int mon, int rea, int con, int acc, bool hum) {
        health = hp;
        money = mon;
        reaction = rea;
        confidence = con;
        accuracy = acc;
        human = hum;
    }

    public int getHealth() {
        return health;
    }

    public int getMoney() {
        return money;
    }

    public int getConfidence() {
        return confidence;
    }

    public int getAccuracy() {
        return accuracy;
    }

    public int getReaction() {
        return reaction;
    }

    public void changeHealth(int change) {
        health += change;
    }

    public void changeMoney(int change) {
        money += change;
    }

    public void changeReaction(int change) {
        reaction += change;
    }

    public void changeConfidence(int change) {
        confidence += change;
    }

    public void changeAccuracy(int change) {
        accuracy += change;
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
