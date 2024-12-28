using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface Spawner
{
    Tile Spawn(Tile spawn);
}

public class GridSpawner : MonoBehaviour, Spawner
{
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Tile linePrefab;
    private int width, height = 5;
    public Tile Spawn(Tile spawn)
    {
        if (spawn == tilePrefab)
        {
            Tile blank = Instantiate(tilePrefab);
            blank.transform.position = new Vector3(width, height, 0);
        }

        else if (spawn == linePrefab)
        {
            Tile line = Instantiate(linePrefab);
            line.transform.position = new Vector3(width, height, 0);
        }
        return spawn;
    }

    //Look on moodle to finish off factory pattern
}
