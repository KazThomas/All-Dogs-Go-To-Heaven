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

    [SerializeField] private List<Tile> objects = new List<Tile>();

    [SerializeField] private Transform cam;

    private bool dogSpawned = false;
    private bool bedSpawned = false;

    private void Awake()
    {
       transform.position = new Vector3( width / 2, height / 2, 0 ); //snaps camera to the middle of the grid
        
        GenerateGrid();
    }

    public List<Tile> getObjects() { return objects; }


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

        SpawnTiles();
        
    }

    void SpawnTiles()
    {
        for (int x1 = 0; x1 < width; x1++)
        {
            for (int y1 = 0; y1 < height; y1++)
            {
                int rand = Random.Range(0, 5);
                int minAmount = 1;
                switch (rand)
                {
                    case 0:
                        //nothing spawns here
                        break;
                    case 1:
                        if (!dogSpawned)
                        {
                            Instantiate(dogPrefab, new Vector3(x1, y1), Quaternion.identity);
                            dogSpawned = true;
                        }
                        break;
                    case 2:
                        if (!bedSpawned)
                        {
                            Instantiate(bedPrefab, new Vector3(x1, y1), Quaternion.identity) ;
                            bedSpawned = true;
                        }
                        break;
                    case 3:
                        if (minAmount <= maxAmount)
                        {
                            Instantiate(rugPrefab, new Vector3(x1, y1), Quaternion.identity);
                            minAmount += 1;
                        }
                        break; 
                    case 4:
                        if (minAmount <= maxAmount)
                        {
                            Instantiate(hooverPrefab, new Vector3(x1, y1), Quaternion.identity);
                            objects.Add(hooverPrefab);
                            minAmount += 1;
                        }
                        break;
                }
            }
        }
    }


  /*  private void PopulateGrid()
    {
        //bool canSpawn = PreventOverlap(spawnPos);

        //singletons
        Vector3 dogPos = new Vector3 (Random.Range(0, width), Random.Range(0, height), 0);
        Vector3 bedPos = new Vector3(Random.Range(0, width), Random.Range(0, height), 0);

        //spawn the things that only need to be one ofs, singletons....
        var dogTile = Instantiate(dogPrefab, dogPos, Quaternion.identity);
        objects.Add(dogTile);
        var bedTile = Instantiate(bedPrefab, bedPos, Quaternion.identity);
        objects.Add(bedTile);

        int fearAmount = Random.Range(1, maxAmount), hideAmount = Random.Range(1, maxAmount); //minimum 1 of each type of non-dog/bed item

        for (int i = 0; i < fearAmount; i++)
        {
            Vector3 randomFearPos = new Vector3(Random.Range(0, width), Random.Range(0, height), 0);
            for (int j = 0; j < hideAmount; j++)
            {
                Vector3 randomHidePos = new Vector3(Random.Range(0, width), Random.Range(0, height), 0);

                var hideTile = Instantiate(rugPrefab, randomHidePos, Quaternion.identity);
                objects.Add(hideTile);
            }
            var fearTile = Instantiate(hooverPrefab, randomFearPos, Quaternion.identity);
            objects.Add(fearTile);
        }

        for (int i = 0; i < objects.Count; i++) //overlap????
        {
            int index = i;
            int next = index + 1;

            //Vector3 dist = Vector3.Distance(objects[i].transform.position, rugPrefab.transform.position);

        }
    } */
}
