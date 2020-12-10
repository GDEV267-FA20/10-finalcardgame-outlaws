using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Place {
    None,       //default, no place
    Doctor,     //-2 money, +1 HP
    Range,      //-1 react, +2 accuracy
    Saloon,     //-1 acc, +2 confidence 
    PoolHall    //+1 react, +1 money, -1 conf
}

[System.Serializable]
public class PlaceDefinition {
    public Place place = Place.None;
    public int HealthChange = 0;
    public int MoneyChange = 0;
    public int ReactionChange = 0;
    public int AccuracyChange = 0;
    public int ConfidenceChange = 0;
}

public class PlaceCards : MonoBehaviour {

    //note: even though placeCards have a place variable, it is unnecessary. 
    //place is generated in ThreeDays when it senses that a placeCards is clicked.
    public Place place;
    private bool clicked;

    // Start is called before the first frame update
    void Start() {
        unClicked();
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonUp(0)) {
            unClicked();
        }
    }

    public Place getPlace() {
        return place;
    }

    public bool getClicked() {
        return clicked;
    }

    public void OnMouseDown() {
        clicked = true;
    }

    public void unClicked() {
        clicked = false;
    }
}
