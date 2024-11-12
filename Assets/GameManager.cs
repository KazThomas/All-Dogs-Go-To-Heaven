using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Card> deck = new List<Card>();
    [SerializeField] private List<Card> discard = new List<Card>();
    [SerializeField] private Transform[] cardSlots;
    [SerializeField] private Transform deckLocation;
    [SerializeField] private Transform discardLocation;
    public bool[] avilableSlots;

    [SerializeField] private TextMeshProUGUI deckText;
    [SerializeField] private TextMeshProUGUI discardText;

    private void Update()
    {
        int deckCount = deck.Count;
        int discardCount = discard.Count;
        deckText.SetText(deckCount.ToString());
        discardText.SetText(discardCount.ToString());
    }

    public void DrawCard()
    {
        //int duplicates = 2;
        if (deck.Count >= 1) //if deck is not empty
        {
            Card randCard = deck[Random.Range(0, deck.Count)]; //randomly gives the player a card that is still in the deck

            Debug.Log(randCard);

            for (int i = 0; i < avilableSlots.Length; i++)
            {
                if (avilableSlots[i])
                {
                    randCard.handIndex = i; //if i = 0 card placement is 0
                    randCard.transform.position = cardSlots[i].position;
                    avilableSlots[i] = false; //because a card is now in that position so move onto the next avilable slot
                    deck.Remove(randCard); //only 1 entity of that card exists in the deck
                    break; //only draws one card at a time
                }
            }
        }
        else
        {
            deck = discard;
            discard.Clear();
            //reconstructs the deck once its more or less empty
        }
    }
}
