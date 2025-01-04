using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    private Spawner tileSpawner;
    private Spawner objectSpawner;
    [SerializeField] private Transform cam;
    [SerializeField] private int width, height;

    private void Awake()
    {
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 2.5f, -10);

        tileSpawner = GetComponent<TileSpawner>();
        objectSpawner = GetComponent<ObjectSpawner>();

        Spawner[] spawners = new Spawner[] { tileSpawner, objectSpawner };
        foreach(Spawner s in spawners)
        {
            s.Spawn(gameObject);
        }
    }
}
