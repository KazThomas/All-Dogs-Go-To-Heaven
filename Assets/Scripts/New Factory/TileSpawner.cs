using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Spawner
{
    GameObject Spawn(GameObject caller);
}

public class TileSpawner : MonoBehaviour, Spawner
{
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private int width, height;

    public GameObject Spawn(GameObject caller)
    {
        GameObject newTile = Instantiate(linePrefab);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var flip = transform.rotation.eulerAngles; //some lines need to be veritcal/horizontal 
                flip.z -= 90;
                if (x == width - 1 && y < height)
                {
                    newTile = Instantiate(linePrefab, new Vector3(x, y), Quaternion.identity);
                    /* if ( x == 3 && y == 0 )
                    {
                        return;
                    } */
                }
                else if (y == 0 && x < width - 1)
                {
                    newTile = Instantiate(linePrefab, new Vector3(x, y), Quaternion.Euler(-flip));
                    //need to figure out why the bottom right tile is the way it is
                }
                else
                {
                    newTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                }
            }
        }
        return newTile;
    }
}
