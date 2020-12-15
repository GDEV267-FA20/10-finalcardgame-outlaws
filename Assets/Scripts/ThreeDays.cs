using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThreeDays : MonoBehaviour {

    [Header("Set in Inspector")]
    public List<Scriptable_object_parent> outlaws;
    public PlaceCards[] placeCards;

    public Text daysText;
    public Text responseText;
    public Text statsText;

    public CharacterOutlaw HumanPlayer;
    public CharacterOutlaw AIPlayer;

    public PlaceDefinition[] placeDefinitions;
    
    public PlaceCards DoctorPlace;
    public PlaceCards PoolHallPlace;
    public PlaceCards SaloonPlace;
    public PlaceCards ShootingRangePlace;
    public PlaceCards ConfirmButton;

    [Header("Set Dynamically")]
    static Dictionary<Place, PlaceDefinition> PLACE_DICTIONARY;

    private Place chosen;
    private int day;
    private string outputResponse;
    private System.Random rand = new System.Random();
    
    void Awake() {
        //Define the dictionary of places
        PLACE_DICTIONARY = new Dictionary<Place, PlaceDefinition>();
        foreach(PlaceDefinition def in placeDefinitions) {
            PLACE_DICTIONARY[def.place] = def;
        }

        //Initialize the two players
        foreach(Scriptable_object_parent cowboy in outlaws) {
            if (cowboy.human == 1) {
                HumanPlayer.setStats(cowboy, true);
            } else if (cowboy.ai == 1) {
                AIPlayer.setStats(cowboy, false);
            }
        }

        //set day and response, then set the UI elements
        day = 1;
        outputResponse = "Pick which place you want to head to today, pardner.";
        newDay();
    }

    // Update is called once per frame
    void Update() {
        //check continuously if any of the places are clicked on; if so, set that place to the target and output text
        if(DoctorPlace.getClicked()) {
            chosen = DoctorPlace.getPlace();
            UpdateResponse("Ah, the doc. Being able to take another bullet's gonna be pricey, but is it worth it?");
            unclickAll();
        } else if (PoolHallPlace.getClicked()) {
            chosen = PoolHallPlace.getPlace();
            UpdateResponse("Dodge a couple loose billiard balls, win a little cash... but what about your gunplay?");
            unclickAll();
        } else if (SaloonPlace.getClicked()) {
            chosen = SaloonPlace.getPlace();
            UpdateResponse("Ah yes, a little whiskey to calm yourself before a duel. Hope your aim is steady enough.");
            unclickAll();
        } else if (ShootingRangePlace.getClicked()) {
            chosen = ShootingRangePlace.getPlace();
            UpdateResponse("Get down to business. Beware, your target might not stand around waiting for you to shoot them.");
            unclickAll();
        }

        //check if the player is trying to confirm
        if(ConfirmButton.getClicked()) {
            Confirm();
            unclickAll();
        }
    }

    //starts a new day.
    public void newDay() {
        daysText.text = "Day " + day;
        responseText.text = outputResponse;
        statsText.text = ("Your Stats: \n\n" +
                         "HP: " + HumanPlayer.getHealth() + "\n" +
                         "Money: " + HumanPlayer.getMoney() + "\n" +
                         "Accuracy: " + HumanPlayer.getAccuracy() + "\n" +
                         "Confidence: " + HumanPlayer.getConfidence() + "\n" +
                         "Reaction Time: " + HumanPlayer.getReaction());
        chosen = ConfirmButton.getPlace();
        unclickAll();
    }

    public void UpdateResponse(string response) {
        responseText.text = response;
    }

    public void Confirm() {
        if(chosen == ConfirmButton.getPlace()) {    
            //if no target, return
            UpdateResponse("Now hold your horses, you haven't picked anywhere to go yet!");
            return;
        } else if(chosen == DoctorPlace.getPlace() && HumanPlayer.getMoney() < 2) {
            //if target is Doctor and player does not have enough money, return
            UpdateResponse("You're gonna need some more cash to get anything done at the Doctor's, buddy.");
            return;
        } else {
            //NPC needs to choose where they want to go
            //choose any place that is not the doctor, using random number
            Place NPCChosen = placeCards[rand.Next(3) + 1].getPlace();
            //if can afford the doctor, then go to the doctor
            if(AIPlayer.getMoney() == 2) {
                NPCChosen = DoctorPlace.getPlace();
            }

            UpdateResponse("Alright. You're heading over to the " + chosen + ", " +
                           "and your opponent is spending the day at the " + NPCChosen + ".");

            changeStats(HumanPlayer, chosen);
            changeStats(AIPlayer, NPCChosen);

            //now that both players' stats were changed, reset and start the next day
            //day changes, check whether or not to...
            day++;
            //...change scene to duel
            if(day == 4) {
                HumanPlayer.pushInfo();
                AIPlayer.pushInfo();
                //SceneManager.LoadScene("_Shootout");
            }

            //if it's not after day 3, then update the UI and get ready for the next day
            Invoke("newDay", 3);
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
        ConfirmButton.unClicked();
    }

    //changes player's stats
    public void changeStats(CharacterOutlaw cowboy, Place place) {
        PlaceDefinition def = GetPlaceDefinition(place);
        cowboy.changeHealth(def.HealthChange);
        cowboy.changeMoney(def.MoneyChange);
        cowboy.changeReaction(def.ReactionChange);
        cowboy.changeConfidence(def.ConfidenceChange);
        cowboy.changeAccuracy(def.AccuracyChange);
    }
}
