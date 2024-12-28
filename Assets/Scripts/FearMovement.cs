using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearMovement : MonoBehaviour
{
    [Range(1, 10)]
    [Tooltip("Move Speed between 1 and 10")]
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Transform fearPoint;
    [SerializeField] private LayerMask walls;
    private int dir;

    private void Start()
    {
        fearPoint.parent = null;
        dir = Random.Range(1, 4);
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, fearPoint.position, moveSpeed * Time.deltaTime);
    }

    public void MovePoint(Vector3 dir)
    {
        Vector3 nextPos = fearPoint.position + dir;
        if (!Physics2D.OverlapCircle(nextPos, 0.5f, walls))
        {
            Debug.Log("Went through");
            fearPoint.position = nextPos;
        }
    }                                                                                                                                                                         
}
