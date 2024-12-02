using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card", order = 0)]

public class ScriptableObj_Card : ScriptableObject
{
    public string cardName;

    public string cardEffect;

    public int amount;

    public Sprite image;
}
