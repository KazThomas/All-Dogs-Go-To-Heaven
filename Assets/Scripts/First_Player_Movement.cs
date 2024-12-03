using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Player_Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] Transform movePoint;
    [SerializeField] LayerMask walls;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null; //no parent
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime); //dog is always moving towards the position of the movepoint 

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f )
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1) //always convert to a positive number
            {
               Move(new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f)); //move point is being moved by the inputs
            }

            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1) //always convert to a positive number
            {
                Move(new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f));
            }
        }
    }

    public void Move(Vector3 direction)
    {
        Vector3 newPos = movePoint.position + direction;
        if (!Physics2D.OverlapCircle(newPos, 0.2f, walls))
        {
            movePoint.position = newPos;
        }
    }
}
