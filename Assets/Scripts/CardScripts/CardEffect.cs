using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "ScriptableObjects/Move", order = 0)]
public abstract class CardEffect : ScriptableObject
{
    [SerializeField] private string cardName;
    [SerializeField] private int amount;
    public string GetCardText()
    {
        return cardName;
    }

    public int GetMoveAmount()
    {
        return amount;
    }

    public abstract void DoAction();
}
