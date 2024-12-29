using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : CommandMove
{
    private void Start()
    {
        name = "Move Down";
        gameObject.name = name;
        target = GameObject.FindGameObjectWithTag("Point");
        card = gameObject.GetComponent<Card>();
    }
    public override void Execute()
    {
        if (name != null)
        {
            direction = new Vector3(0, -1, 0);
            target.transform.position += direction;
            card.CardPressed();
        }
    }

    public override void Undo()
    {
        if (name != null)
        {
            direction = new Vector3(0, 1, 0);
            target.transform.position = direction;
        }
    }
}
