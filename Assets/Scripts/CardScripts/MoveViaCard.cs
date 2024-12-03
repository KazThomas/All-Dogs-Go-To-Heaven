using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "ScriptableObjects/Move", order = 1)]
public class MoveViaCard : CardEffect
{
    public override void DoAction()
    {
        name = cardName;
        GameObject dog = GameObject.FindGameObjectWithTag("Dog");
        GameObject movePoint = GameObject.FindGameObjectWithTag("Point");
        LayerMask walls = LayerMask.GetMask("Wall");

        int move = dog.GetComponent<DogMovement>().GetMovement();

        Vector3 direction;

        if (dog != null)
        {
            First_Player_Movement dogmove = new First_Player_Movement();

            switch (name)
            {
                case "Move Down":
                    direction = new Vector3(0, 1, 0); //need to replace the numbers with move but idk hows
                    break;
                case "Move Up":
                    direction = new Vector3(0, -1, 0);
                    break;
                case "Move Right":
                    direction = new Vector3(1, 0, 0);
                    break;
                case "Move Left":
                    direction = new Vector3(-1, 0, 0);
                    break;
                default:
                    direction = Vector3.zero;
                    break;
            }
            dogmove.Move(direction);
        }
    }
}
