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
    public List<Card> cards;
    public List<Card> deck;
    public List<Card> hand;
    public List<Card> discard;
    public bool ifShuffled = false;
    public Transform deckAnchor;

    


    [Header("Set In Inspector")]
    public GameObject prefabAimedShot;
    public GameObject prefabQuickShot;
    public GameObject prefabHesitate;
    public GameObject prefabDodge;
    public Vector3 deckLoc;

    public Copperplate copperplate;
    public Sabrina sabrina;
    public Sally sally;
    public William william;
    
    

   
    public Card MakeCard(int cNum)
    {
        GameObject cgo;
        switch (cNum)
        {
            default:
                cgo = Instantiate(prefabAimedShot) as GameObject;
                break;
            case 1:
                cgo = Instantiate(prefabQuickShot) as GameObject;
                break;
            case 2:
                cgo = Instantiate(prefabHesitate) as GameObject;
                break;
            case 3:
                cgo = Instantiate(prefabDodge) as GameObject;
                break;

        }
        
        cgo.transform.parent = deckAnchor;
        Card card = cgo.GetComponent<Card>();
        // cgo.transform.localPosition = deckLoc;
        cgo.transform.localPosition = new Vector3( deckLoc.x, deckLoc.y, (deck.Count * .1f));
        card.setType(cNum);
        card.setFace(false);

        return card;

    }
    public void Start()
    {

    }
    // Call this method after Scene(1) to populate deck
    public void AddCard(Card newCard)
    {
        deck.Add(newCard);
        

    }
    // Call this method after every draw to remove from deck
    public void RemoveCard(Card newCard)
    {
        deck.Remove(newCard);
    }
    public void Shuffle(ref List<Card> oDeck)
    {
        // boolean to check if its shuffled / full deck
        // can use this to trigger next event?
        ifShuffled = true;
        List<Card> tDeck;

        int ndx; // This will hold the index of the card to be moved
        tDeck = new List<Card>(); // Initialize the temporary List
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
    public Card Draw()
    {
        Card cd = deck[0];
        
        // add top card to hand
        hand.Add(deck[0]);
        cd.state = cardState.toHand;
        // remove top card from deck
        RemoveCard(deck[0]);
        
        return cd;
    }
    public List<Card> Draw6()
    {
        List<Card> cdList;
        cdList = new List<Card>();

        for (int i = 0; i < 5; i++)
        {
            Card cd = deck[0];
            // add top card to hand
            hand.Add(deck[0]);
            cd.state = cardState.toHand;
            // remove top card from deck
            RemoveCard(deck[0]);
            cdList.Add(cd);
        }

        return cdList;
    }
    
    public void MakeDeck(ScriptableObject character)
    {
        // ******need to figure out who is the player playing / ai playing******

        // for each accuracy point add aimed shot
        //for(int i = 0; i < character.accuracy; i++)
            AddCard((MakeCard(0)));
        // for each confidence point add quick shot
        //for (int i = 0; i < character.confidence; i++)
            AddCard((MakeCard(1)));
        // for each reaction time point add dodge
        //for (int i = 0; i < character.reaction; i++)
            AddCard((MakeCard(3)));

        // get list count, add hesitate cards untill count = 18
        for (int i = deck.Count; i<18; i++)
        {
            AddCard((MakeCard(2)));
        }
        
       
    }
    
}
