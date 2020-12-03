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
    public int HPChange = 0;
    public int MoneyChange = 0;
    public int ReactionChange = 0;
    public int AccuracyChange = 0;
    public int ConfidenceChange = 0;
}


public class ThreeDays : MonoBehaviour {
    
    [Header("Set in Inspector")]
    public PlaceDefinition[] placeDefinitions;
    static Dictionary<Place, PlaceDefinition> PLACE_DICTIONARY;
    
    void Awake() {
        //Define the dictionary of places
        PLACE_DICTIONARY = new Dictionary<Place, PlaceDefinition>();
        foreach(PlaceDefinition def in placeDefinitions) {
            PLACE_DICTIONARY[def.place] = def;
        }
    }

    static public PlaceDefinition GetPlaceDefinition(Place place) {
        if(PLACE_DICTIONARY.ContainsKey(place)) {
          
        }
        //only returns this if it fails to find the called-for place
        return (new PlaceDefinition());
    }
}
