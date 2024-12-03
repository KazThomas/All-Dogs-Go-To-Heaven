using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameObject dog;
    private Rigidbody2D rb;

    private Collider2D col;
    [SerializeField] LayerMask tileLayer;



    //NOT BEING USED


    /* [SerializeField] private float moveSpeed = 5f;
    [SerializeField] Transform movePoint; */
    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.FindWithTag("Dog");
        rb = dog.GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    /* bool MyCollisions()
    {
        Collider2D[] hitCols = Physics2D.OverlapCircleAll(gameObject.transform.position, 1, tileLayer);
        int i = 0;
        while (i < hitCols.Length)
        {
            Debug.Log("Hit : " + hitCols[i].name + i);
            i++;
        }
    } */
}
