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

    private void Start()
    {
        fearPoint.parent = null;
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, fearPoint.position, moveSpeed * Time.deltaTime);
    }

    public void FearMove(Vector3 dir)
    {
        Vector3 nextPos = fearPoint.position + dir;
        if (!Physics2D.OverlapCircle(nextPos, 0.2f, walls))
        {
            fearPoint.position = nextPos;
        }
    }
}
