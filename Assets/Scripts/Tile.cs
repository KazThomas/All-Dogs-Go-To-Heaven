using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameObject dog;
    private Rigidbody2D rb;

    /* [SerializeField] private float moveSpeed = 5f;
    [SerializeField] Transform movePoint; */
    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.FindWithTag("Dog");
        rb = dog.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }
}
