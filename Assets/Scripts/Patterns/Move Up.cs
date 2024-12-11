using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : CommandMove
{
    private void Start()
    {
        name = "Move Up";
        gameObject.name = name;
    }
    public override void Execute()
    {
        if (name != null )
        {
            direction = new Vector3( -1, 0, 0 );
            target.transform.position = direction;
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

    // Start is called before the first frame update

}
