using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThreeDays : MonoBehaviour {

    [Header("Set in Inspector")]
    public List<Scriptable_object_parent> outlaws;
    public PlaceCards[] placeCards;
    public PlaceCards ConfirmButtonPrefab;

    [Header("Set Dynamically")]
    private OutlawCharacter HumanPlayer;
    private OutlawCharacter AIPlayer;

    public PlaceDefinition[] placeDefinitions;
    static Dictionary<Place, PlaceDefinition> PLACE_DICTIONARY;

    private PlaceCards DoctorPlace;
    private PlaceCards PoolHallPlace;
    private PlaceCards SaloonPlace;
    private PlaceCards ShootingRangePlace;

    private PlaceCards ConfirmButton;

    private Canvas canvas;

    private Place chosen;

    private int day;

    private System.Random rand = new System.Random();
    
    void Awake() {
        //Define the dictionary of places
        PLACE_DICTIONARY = new Dictionary<Place, PlaceDefinition>();
        foreach(PlaceDefinition def in placeDefinitions) {
            PLACE_DICTIONARY[def.place] = def;
        }

        //find the canvas
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();

        //instantiate all places and confirm button, all as PlaceCards, 
        //which are essentially buttons in retrospect
        //also, it changes their parent to be the canvas
        DoctorPlace = (Instantiate(placeCards[0]) as PlaceCards);
        DoctorPlace.transform.parent = canvas.transform;

        PoolHallPlace = (Instantiate(placeCards[1]) as PlaceCards);
        PoolHallPlace.transform.parent = canvas.transform;

        SaloonPlace = (Instantiate(placeCards[2]) as PlaceCards);
        SaloonPlace.transform.parent = canvas.transform;

        ShootingRangePlace = (Instantiate(placeCards[3]) as PlaceCards);
        ShootingRangePlace.transform.parent = canvas.transform;

        ConfirmButton = (Instantiate(ConfirmButtonPrefab) as PlaceCards);
        ConfirmButton.transform.parent = canvas.transform;

        //set player's chosen place to None
        chosen = ConfirmButton.getPlace();

        //set day to 1
        day = 1;

        //Initialize the two players
        foreach(Scriptable_object_parent cowboy in outlaws) {
            if (cowboy.human == 1) {
                HumanPlayer = new OutlawCharacter(cowboy, true);
            } else if (cowboy.ai == 1) {
                AIPlayer = new OutlawCharacter(cowboy, false);
            }
        }
    }

    // Update is called once per frame
    void Update() {
        //check continuously if any of the places are clicked on, if so set that place to the target
        if(DoctorPlace.getClicked() && chosen != DoctorPlace.getPlace()) {
            chosen = DoctorPlace.getPlace();
            unclickAll();
        } else if (PoolHallPlace.getClicked() && chosen != PoolHallPlace.getPlace()) {
            chosen = PoolHallPlace.getPlace();
            unclickAll();
        } else if (SaloonPlace.getClicked() && chosen != SaloonPlace.getPlace()) {
            chosen = SaloonPlace.getPlace();
            unclickAll();
        } else if (ShootingRangePlace.getClicked() && chosen != ShootingRangePlace.getPlace()) {
            chosen = ShootingRangePlace.getPlace();
            unclickAll();
        }

        //check if the player is trying to confirm
        if(ConfirmButton.getClicked()) {
            Confirm();
            unclickAll();
        }
    }

    public void Confirm() {
        if(chosen == ConfirmButton.getPlace()) {    //if no target, return
            return;
            //"you haven't picked anywhere to go, pardner!"
        }   //if target is Doctor and player does not have enough money, return
        else if(chosen == DoctorPlace.getPlace() && HumanPlayer.getMoney() <= 1) {        
            return;
            //"hey, you don't have enough money for that!"
        } else {
            //NPC needs to choose where they want to go
            //choose any place that is not the doctor, using random number
            Place NPCChosen = placeCards[rand.Next(3) + 1].getPlace();
            //if can afford the doctor, then go to the doctor
            if(AIPlayer.getMoney() == 2) {
                NPCChosen = DoctorPlace.getPlace();
            }

            changeStats(HumanPlayer, chosen);
            changeStats(AIPlayer, NPCChosen);

            //now that both players' stats were changed, reset and start the next day
            //set player's target position to None
            chosen = ConfirmButton.getPlace();

            //day changes, check whether or not to...
            day++;
            if(day == 4) {
                //...change scene to duel
                HumanPlayer.pushInfo();
                AIPlayer.pushInfo();
                //LoadNextScene or something
            }
        }
    }

    //used to determine how to change the player's stats 
    static public PlaceDefinition GetPlaceDefinition(Place place) {
        if(PLACE_DICTIONARY.ContainsKey(place)) {
            return (PLACE_DICTIONARY[place]);
        }
        //only returns this if it fails to find the called-for place
        return (new PlaceDefinition());
    }

    //ensure multiple buttons aren't being clicked on at once
    public void unclickAll() {
        DoctorPlace.unClicked();
        PoolHallPlace.unClicked();
        SaloonPlace.unClicked();
        ShootingRangePlace.unClicked();
    }

    //changes player's stats
    public void changeStats(OutlawCharacter cowboy, Place place) {
        PlaceDefinition def = GetPlaceDefinition(place);
        cowboy.changeHealth(def.HealthChange);
        cowboy.changeMoney(def.MoneyChange);
        cowboy.changeReaction(def.ReactionChange);
        cowboy.changeConfidence(def.ConfidenceChange);
        cowboy.changeAccuracy(def.AccuracyChange);
    }
}
