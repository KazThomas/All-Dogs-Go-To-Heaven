using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private GameObject card;

    [SerializeField] private ScriptableObj_Card scriptCard;
    [SerializeField] private MoveViaCard move;

    [SerializeField] private string cardName;

    private GameManager gm;
    private GameObject dog;
    private bool hasBeenPlayed;

    public int handIndex;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
        dog = GameObject.FindGameObjectWithTag("Dog");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CardPressed()
    {
        if (!hasBeenPlayed)
        {
            transform.position += Vector3.up * 5 * Time.deltaTime; //highlights the card thats been played
            hasBeenPlayed = true;

        }
    }
}
