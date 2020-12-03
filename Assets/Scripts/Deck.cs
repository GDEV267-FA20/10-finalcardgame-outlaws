using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    // This is really just gonna be an array of cards, 
    // shouldnt be as complicated as bartok since we are
    // not doing xml?
    [Header("Set Dynamically")]

    public List<string> cardNames;
    public List<GameObject> deck;
    public bool ifShuffled = false;

   // Call this method after Scene(1) to populate deck
    public void AddCard(GameObject newCard)
    {
        deck.Add(newCard);
        // Deck is full at 18 cards so lets shuffle
        if((deck.Count - 1) == 17)
        {
            Shuffle(ref deck);
        }
    }
    // Call this method after every draw to remove from deck
    public void RemoveCard(GameObject newCard)
    {
        
        deck.Remove(newCard);
    }
    public void Shuffle(ref List<GameObject> oDeck)
    {
        // boolean to check if its shuffled / full deck
        // can use this to trigger next event?
        ifShuffled = true;
        List<GameObject> tDeck;

        int ndx; // This will hold the index of the card to be moved
        tDeck = new List<GameObject>(); // Initialize the temporary List
        // Repeat as long as there are cards in the original List
        while (oDeck.Count > 0)
        {
            // Pick the index of a random card
            ndx = Random.Range(0, oDeck.Count);
            // Add that card to the temporary List
            tDeck.Add(oDeck[ndx]);
            // And remove that card from the original List
            oDeck.RemoveAt(ndx);
        }
        
        oDeck = tDeck;
        
    }
}
