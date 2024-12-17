using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveLeft : CommandMove
{
    private void Start()
    {
        name = "Move Left";
        gameObject.name = name;
        target = GameObject.FindGameObjectWithTag("Point");
        card = gameObject.GetComponent<Card>();
    }
    public override void Execute()
    {
        if (name != null)
        {
            direction = new Vector3(-1, 0, 0);
            target.transform.position += direction;
            card.CardPressed();
        }
    }

    public override void Undo()
    {
        if (name != null)
        {
            direction = new Vector3(1, 0, 0);   
            target.transform.position = direction;
        }
    }
}
