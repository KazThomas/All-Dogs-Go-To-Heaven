using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    private void Start()
    {
        int player_x = Random.Range(0, 7);
        int player_y = Random.Range(0, 2);

        Map m = new Map(3, 8);

        
    }
}
