using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffect : ScriptableObject
{
    [SerializeField] private int moveAmount;
    [SerializeField] private string cardText;

    public string GetCardText()
    {
        return cardText;
    }

    public int GetMoveAmount()
    {
        return moveAmount;
    }

    public abstract void DoAction();
}