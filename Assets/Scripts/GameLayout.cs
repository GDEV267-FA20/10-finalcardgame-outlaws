using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameLayout : MonoBehaviour
{
    #region positions in worldspace
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
    #endregion 
    #region dynamic laods and sets

    public List<Scriptable_object_parent> outlaws;
    public Sabrina sabrina;
    public Copperplate copperplate;
    public Sally sally;
    public William william;
    private Scriptable_object_parent human;
    private Scriptable_object_parent bot;

    [Header("Set Dynamically")]
    public Deck playerDeck;
    public Deck aiDeck;
    public Scriptable_object_parent playerCharacter;
    public Scriptable_object_parent aiCharacter;
    #endregion
    public void Awake()
    {
        outlaws.Add(sabrina);
        outlaws.Add(copperplate);
        outlaws.Add(sally);
        outlaws.Add(william);

    }
    public void Start()
    {
        //adjust stats 
        IEnumerable<Scriptable_object_parent> _human =
            from outlaw in outlaws
            where outlaw.human == 1
            select outlaw;

        IEnumerable<Scriptable_object_parent> _bot =
            from inlaw in outlaws
            where inlaw.ai == 1
            select inlaw;
        
        foreach(Scriptable_object_parent s in _human)
        {
            human = (Scriptable_object_parent)s;
        }
        foreach(Scriptable_object_parent s in _bot)
        {
            bot = (Scriptable_object_parent)s;
        }
        bot.Special_Effect(human);
        human.Special_Effect(bot);
        aiCharacter = bot;
        playerCharacter = human;
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
       

        //playerCharacterLocation.transfrom.position;
        //aiCharacterLocation.transform.position;

        // Draw 6 cards into each hand
        playerDeck.Draw6();
        aiDeck.Draw6();

    }
    public void Update()
    {
        
        for(int i= 0; i < playerDeck.hand.Count; i++)
        {
            playerDeck.hand[i].transform.position = playerHand.transform.position
                - new Vector3(i, 0.0f, 0.0f);
        }
        for(int i= 0; i < aiDeck.hand.Count; i++)
        {
            aiDeck.hand[i].transform.position = aiHand.transform.position
                - new Vector3(i, 0.0f, 0.0f);
        }
    }
}
