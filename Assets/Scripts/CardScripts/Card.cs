using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private GameObject card;

    [SerializeField] private ScriptableObj_Card scriptCard;
    [SerializeField] private MoveViaCard move;
    public string cardName;

    private GameManager gm;
    private GameObject dog;
    private bool hasBeenPlayed;
    private BoxCollider2D col;

    public int handIndex;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
        dog = GameObject.FindGameObjectWithTag("Dog");
        col = gameObject.GetComponent<BoxCollider2D>();
    }
    public void CardPressed()
    {
        if (!hasBeenPlayed)
        {
            transform.position += Vector3.up * 5 * Time.deltaTime; //highlights the card thats been played
            hasBeenPlayed = true;
            move.DoAction();
            gm.avilableSlots[handIndex] = true; //reopens the hand for a new card
            Invoke("Discard", 2f);
        }
    }

    private void Discard()
    {
        gm.discard.Add(this);
        gameObject.SetActive(false); //hides the card away
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(cardName);
            CardPressed();
        }
    }
}
