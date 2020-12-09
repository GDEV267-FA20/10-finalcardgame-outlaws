using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayout : MonoBehaviour
{
    [Header("Set In Inspector")]
    public GameObject playerHand;
    public GameObject aiHand;
    public GameObject playerCharacter;
    public GameObject playerTarget;
    public GameObject playerDrawPile;
    public GameObject playerDiscardPile;
    public GameObject aiTarget;
    public GameObject aiDrawPile;
    public GameObject aiDiscardPile;
    public GameObject aiCharacter;

    [Header("Set Dynamically")]
    public Deck playerDeck;
    public Deck aiDeck;

    public void Start()
    {
        playerDrawPile.AddComponent<Deck>();
        playerDeck = playerDrawPile.GetComponent<Deck>();
        //aiDeck = GetComponent<Deck>();
        
        playerDeck.MakeDeck();
        //aiDeck.MakeDeck();
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
