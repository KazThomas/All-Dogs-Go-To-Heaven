using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "ScriptableObjects/Move", order = 1)]
public class MoveViaCard : CardEffect
{
    public override void DoAction()
    {
        GameObject dog = GameObject.FindGameObjectWithTag("Dog");
        
        if (dog != null)
        {
            Vector3 up = new Vector3(0f, -1, 0f);
            
            Vector2 right = new Vector3(0f, 1, 0f);
            switch (cardName)
            {
                case "Move Up":
                    dog.GetComponent<DogMovement>().SetPos(up);
                    break;
                case "Move Down":
                    dog.GetComponent<DogMovement>().SetPos(-up);//can just reverse the up doesnt need a new vector 3 
                    break;
                case "Move Right":
                    dog.GetComponent<DogMovement>().SetPos(right);
                    break;
                case "Move Left":
                    dog.GetComponent <DogMovement>().SetPos(-right);
                    break;
            }
        }
    }
}
