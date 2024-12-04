using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Range(1, 10)]
    [Tooltip("Move Speed between 1 and 10")]
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Transform movePoint;
    [SerializeField] LayerMask walls;

    private GameObject dog;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        dog = GameObject.FindGameObjectWithTag("Dog");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dog.transform.position = Vector3.MoveTowards(dog.transform.position, movePoint.position, moveSpeed * Time.deltaTime);
    }

    public void DogMove(Vector3 direction)
    {
        Vector3 newPos = movePoint.position + direction;
        if (!Physics2D.OverlapCircle(newPos, 0.2f, walls))
        {
            movePoint.position = newPos;
        }
    }
}