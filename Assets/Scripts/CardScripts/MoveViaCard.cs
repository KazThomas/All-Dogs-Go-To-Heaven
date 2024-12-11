using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveViaCard : CardEffect
{
    public override void DoAction()
    {
        name = GetCardText();
        GameObject dog = GameObject.FindGameObjectWithTag("Dog");
        GameObject movePoint = GameObject.FindGameObjectWithTag("Point");
        LayerMask walls = LayerMask.GetMask("Wall");

        int moveAmount = GetMoveAmount();

        Vector3 direction;

        if (dog != null)
        {
            switch (name)
            {
                case "Move Down":
                    direction = new Vector3(0, moveAmount, 0); 
                    break;
                case "Move Up":
                    direction = new Vector3(0, moveAmount, 0);
                    break;
                case "Move Right":
                    direction = new Vector3(moveAmount, 0, 0);
                    break;
                case "Move Left":
                    direction = new Vector3(moveAmount, 0, 0);
                    break;
                default:
                    direction = Vector3.zero;
                    break;
            }
            dog.GetComponent<Movement>().DogMove(direction);
        }
    }
}
