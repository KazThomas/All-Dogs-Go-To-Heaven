using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GridSpawner : MonoBehaviour
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
        transform.position = new Vector3(width / 2, height / 2, 0);

        GenerateGrid();
    }

    public List <Tile> getObjects() { return objects; }

    private void GenerateGrid() //to redo grid after level complete
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
                int rand = Random.Range(0, 4);
                switch (rand)
                {
                    case 0:
                        return;
                    case 1:
                        Instantiate(dogPrefab, new Vector3(x, y), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(bedPrefab, new Vector3(x, y), Quaternion.identity) ; 
                        break;
                    case 3:
                        Instantiate(hooverPrefab, new Vector3(x, y), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(rugPrefab, new Vector3(x, y), Quaternion.identity);
                        break;
                }
            }
        }
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 1.5f, -10);

       
    }

   /*( public Tile PopulateGrid()
    {
        
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                return tilePrefab;
            case 1:
                return dogPrefab;
            case 2:
                return bedPrefab;
            case 3:
                return hooverPrefab;
            case 4:
                return rugPrefab;
        }
        return null;
    } */

}
