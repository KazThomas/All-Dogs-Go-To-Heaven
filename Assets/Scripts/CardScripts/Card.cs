using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Card : MonoBehaviour
{
    [SerializeField] private GameObject card;

    [SerializeField] private string cardName;

    private GameManager gm;
    
    private bool hasBeenPlayed = false;
   

    public int handIndex;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
    }
    public void CardPressed()
    {
        Debug.Log("PRESSED!");
        if (!hasBeenPlayed) //&& gm.actionsPerTurn > 0)
        {
            transform.position += Vector3.up * 5 * Time.deltaTime; //highlights the card thats been played
            hasBeenPlayed = true;
            gm.actionsPerTurn--;
            gm.avilableSlots[handIndex] = true; //reopens the hand for a new card
            Invoke("Discard", 0.1f);
        }
    }

    private void Discard()
    {
        gm.discard.Add(this);
        hasBeenPlayed = false;
        gameObject.SetActive(false); //hides the card away
        
    }
}
