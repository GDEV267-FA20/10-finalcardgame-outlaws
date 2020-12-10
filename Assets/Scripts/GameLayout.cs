using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayout : MonoBehaviour
{
    [Header("Set In Inspector")]
    public GameObject playerHand;
    public GameObject aiHand;
    public GameObject playerCharacterLocation;
    public GameObject playerTarget;
    public GameObject playerDrawPile;
    public GameObject playerDiscardPile;
    public GameObject aiTarget;
    public GameObject aiDrawPile;
    public GameObject aiDiscardPile;
    public GameObject aiCharacterLocation;

    [Header("Set Dynamically")]
    public Deck playerDeck;
    public Deck aiDeck;
    public Scriptable_object_parent playerCharacter;
    public Scriptable_object_parent aiCharacter;

    public void Start()
    {
        // put each script into variables
        playerDeck = playerDrawPile.GetComponent<Deck>();
        aiDeck = aiDrawPile.GetComponent<Deck>();
        
        // Make both decks passing in scriptable object taken from Town Scene
        playerDeck.MakeDeck(playerCharacter);
        aiDeck.MakeDeck(aiCharacter);
        LayoutGame();
    }
    public void LayoutGame()
    {
        // Place both player and ai decks at their respective drawpile positions
        for(int i=0; i< playerDeck.deck.Count; i++)
        {
            playerDeck.deck[i].transform.position = playerDrawPile.transform.position;
        }
        for (int i = 0; i < aiDeck.deck.Count; i++)
        {
            aiDeck.deck[i].transform.position = aiDrawPile.transform.position;
        }
        // Place player and ai character sprites at their respective character positions
        // ***** Need to recieve information from Character Select screen****

        //playerCharacterLocation.transfrom.position;
        //aiCharacterLocation.transform.position;

        // Draw 6 cards into each hand
        playerDeck.Draw6();
        aiDeck.Draw6();

    }
    public void Update()
    {
        /*for(int i= 0; i < playerDeck.hand.Count; i++)
        {
            playerDeck.hand[i].transform.position = playerHand.transform.position
                - new Vector3(i, 0.0f, 0.0f);
        }*/
        /*for(int i= 0; i < aiDeck.hand.Count; i++)
        {
            aiDeck.hand[i].transform.position = aiHand.transform.position
                - new Vector3(i, 0.0f, 0.0f);
        }*/
    }
}
