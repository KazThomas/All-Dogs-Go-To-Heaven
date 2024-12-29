using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    private Spawner tileSpawner;
    private ObjSpawner objectSpawner;
    [SerializeField] private Transform cam;
    [SerializeField] private int width, height;

    private void Awake()
    {
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 1.5f, -10);
        tileSpawner = GetComponent<Spawner>();
        objectSpawner = GetComponent<ObjSpawner>();


        tileSpawner.Spawn(gameObject);
        objectSpawner.SpawnObj(gameObject);
        //SpawnTiles();

    }

    void SpawnTiles()
    {
        
    }
}
