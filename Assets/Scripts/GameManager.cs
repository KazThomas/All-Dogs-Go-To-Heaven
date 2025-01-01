using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Card> deck = new List<Card>(); //change to stacks
    [SerializeField] private Stack<Card> Stackdeck = new Stack<Card>();
    public List<Card> discard = new List<Card>();
    [SerializeField] private Transform[] cardSlots;
    [SerializeField] private Transform deckLocation;
    [SerializeField] private Transform discardLocation;
    public bool[] avilableSlots;

    public int actionsPerTurn = 0;

    [SerializeField] private TextMeshProUGUI deckText;
    [SerializeField] private TextMeshProUGUI discardText;

    private void Update()
    {
        deckText.SetText(deck.Count.ToString());
        discardText.SetText(discard.Count.ToString());


        //convert stack to array
        //temp array -> with array.Orderby (x => random.value).toarray()
        //for each temp array
        //clear stack
        //then push in for each
    }

   /* private Stack<Card> Shuffle(Stack<Card> deck) // Fisher-Yates Shuffle
    {
        int i = 0;
        int max = deck.Count;
        int r = 0;

        Card card = null;
        List<Card> temp = new List<Card>();
        temp.AddRange(deck);

        while (i < max)
        {
            r = Random.Range(i, deck.Count);
            card = temp[i];
            temp[i] = temp[r];
            temp[r] = card;
            i++;
        }
        return deck;
    } */

    void Shuffle(Stack<Card> stack)
    {
        var arr = stack.ToArray();
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            Card temp = arr[i];
            int index = Random.Range(0, arr.Length - 1);
            arr[i] = arr[index];
            arr[index] = temp;
        }
        stack = new Stack<Card>(arr);
    } 


    public void DrawCard() //currently drawing from the MoveSystem 
    {
        if (deck.Count >= 1) //if deck is not empty
        {
            Card randCard = deck[Random.Range(0, deck.Count)]; //randomly gives the player a card that is still in the deck
            //Debug.Log(randCard); what card is being drawn

            for (int i = 0; i < avilableSlots.Length; i++)
            {
                if (avilableSlots[i])
                {
                    randCard.gameObject.SetActive(true);
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
            //reconstructs the deck once its more or less empty
        }
    }
}
