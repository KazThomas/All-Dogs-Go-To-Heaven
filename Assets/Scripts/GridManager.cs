using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height; //size of map
    [SerializeField] private int maxAmount = 2; //amount of fears/hiding places
    
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Tile linePrefab;
    [SerializeField] private Tile dogPrefab;
    [SerializeField] private Tile bedPrefab;
    [SerializeField] private Tile hooverPrefab;
    [SerializeField] private Tile rugPrefab;

    [SerializeField] private Transform cam;

    public Collider2D[] col;
    [SerializeField] private float radius;

    private void Awake()
    {
        col = Physics2D.OverlapCircleAll(transform.position, radius);
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                
                var flip = transform.rotation.eulerAngles;
                flip.z -= 90;
                if (x == width - 1 && y < height)
                {
                    var lineTile = Instantiate(linePrefab, new Vector3(x, y), Quaternion.identity);
                    /* if ( x == 3 && y == 0 )
                    {
                        return;
                    } */
                }
                else if (y == 0 && x < width - 1)
                {
                    var flipTile = Instantiate(linePrefab, new Vector3(x, y), Quaternion.Euler(-flip));
                    //need to figure out why the bottom right tile is the way it is
                }
                else
                {
                    var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity); 
                }
            }
        }
        cam.transform.position = new Vector3 ((float) width/2 - 0.5f, (float) height/2  - 1.5f, - 10);

        PopulateGrid();
        
    }

    private void PopulateGrid()
    {
        //singletons
        int playerX = Random.Range(0, width), bedX = Random.Range(0, width);
        int playerY = Random.Range(0, height), bedY = Random.Range(0, height);

        //potential multiples
        int hideX = Random.Range(0, width), fearX = Random.Range(0, width);
        int hideY = Random.Range(0, height), fearY = Random.Range(0, height);

        //spawn the things that only need to be one ofs, singletons....
        var dogTile = Instantiate(dogPrefab, new Vector3(playerX - 0.1f, playerY), Quaternion.identity);
        var bedTile = Instantiate(bedPrefab, new Vector3(bedX, bedY), Quaternion.identity);

        int fearAmount = Random.Range(1, maxAmount); //minimum 1 of each type of non-dog/bed item
        int hideAmount = Random.Range(1, maxAmount);

        for (int i = 0; i < fearAmount; i++)
        {
            for (int j = 0; j < hideAmount; j++)
            {
                var hideTile = Instantiate(rugPrefab, new Vector3(hideX, hideY), Quaternion.identity);
            }
            var fearTile = Instantiate(hooverPrefab, new Vector3(fearX, fearY), Quaternion.identity);
        }
    }
}
