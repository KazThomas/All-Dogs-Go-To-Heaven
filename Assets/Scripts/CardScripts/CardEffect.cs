using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffect : ScriptableObj_Card
{
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
