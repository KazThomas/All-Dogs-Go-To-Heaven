using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height; //size of map - 5x5
    [SerializeField] private int maxAmount = 2; //2 reasonable amount to avoid 
    
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Tile linePrefab;
    [SerializeField] private Tile dogPrefab;
    [SerializeField] private Tile bedPrefab;
    [SerializeField] private Tile hooverPrefab;
    [SerializeField] private Tile rugPrefab;

    [SerializeField] private Transform cam;

    public Collider2D[] col; //overlapping spawn fixes?
    [SerializeField] private float radius;
    

    private void Awake()
    {
       transform.position = new Vector3( width / 2, height / 2, 0 ); //snaps camera to the middle of the grid
        
        GenerateGrid();
    }


   public void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                
                var flip = transform.rotation.eulerAngles; //some lines need to be veritcal/horizontal 
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
        //bool canSpawn = PreventOverlap(spawnPos);

        //singletons
        Vector3 dogPos = new Vector3 (Random.Range(0, width), Random.Range(0, height), 0);
        Vector3 bedPos = new Vector3(Random.Range(0, width), Random.Range(0, height), 0);

        //spawn the things that only need to be one ofs, singletons....
        var dogTile = Instantiate(dogPrefab, dogPos, Quaternion.identity);
        var bedTile = Instantiate(bedPrefab, bedPos, Quaternion.identity);

        int fearAmount = Random.Range(1, maxAmount), hideAmount = Random.Range(1, maxAmount); //minimum 1 of each type of non-dog/bed item

        for (int i = 0; i < fearAmount; i++)
        {
            Vector3 randomFearPos = new Vector3(Random.Range(0, width), Random.Range(0, height), 0);
            for (int j = 0; j < hideAmount; j++)
            {
                Vector3 randomHidePos = new Vector3(Random.Range(0, width), Random.Range(0, height), 0);

                var hideTile = Instantiate(rugPrefab, randomHidePos, Quaternion.identity);
            }
            var fearTile = Instantiate(hooverPrefab, randomFearPos, Quaternion.identity);
        }
    }

   /* bool PreventOverlap(Vector3 spawnPos)
    {
        col = Physics2D.OverlapCircleAll(transform.position, radius);

        for (int i = 0; i < col.Length; i++)
        {
            Vector3 center = col[i].bounds.center;
            float width = col[i].bounds.extents.x;
            float height = col[i].bounds.extents.y;

            float leftExtent = center.x - width;
            float rightExtent = center.x + width;
            float topExtent = center.y - height;
            float bottomExtent = center.y + height;

            if (spawnPos.x >= leftExtent && spawnPos.x <= rightExtent)
            {
                if (spawnPos.y >= bottomExtent && spawnPos.y <= topExtent)
                {
                    return false;
                }
            }
            
        }
        return true;
    } */
}
