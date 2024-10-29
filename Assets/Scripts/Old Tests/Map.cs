using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    [SerializeField] private GameObject[,] tile;
    private int width, height;

    private enum TileTypes
    {
        EMPTY, HIDING_PLACE, FEAR //Only needs 1 Dog and 1 Bed object.
    }

    private void Start()
    {

    }

    public Map(int width, int height)
    {
        this.width = width;
        this.height = height;

        tile = new GameObject[height, width]; //the array will always be whatever the output of width*height is, which in this case is 18

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                TileTypes type;

                int t = Random.Range(0, 3);
                type = (TileTypes)t;

                switch (type)
                {
                    case TileTypes.EMPTY:
                        tile[y, x] = new GameObject();
                        break;
                   /* case TileTypes.FEAR:
                        tile[y, x] = */ 
                }
            }
        }
    }
}
