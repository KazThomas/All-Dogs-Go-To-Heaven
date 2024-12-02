using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    
    [SerializeField] private List<Card> cards;

    private void Start()
    {
        cards = new List<Card>();
        
    }
}
