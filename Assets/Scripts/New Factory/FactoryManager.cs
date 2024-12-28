using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    private Spawner tileSpawner;
    [SerializeField] private Transform cam;
    [SerializeField] private int width, height;

    [SerializeField] private GameObject dogPrefab;
    [SerializeField] private GameObject bedPrefab;
    [SerializeField] private GameObject hooverPrefab;
    [SerializeField] private GameObject rugPrefab;

    [SerializeField] private List<GameObject> objects = new List<GameObject>();

    private int maxAmount = 2;

    private bool dogSpawned = false;
    private bool bedSpawned = false;
    private void Start()
    {
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 1.5f, -10);
        tileSpawner = GetComponent<Spawner>();

        tileSpawner.Spawn(gameObject);
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
                            Instantiate(bedPrefab, new Vector3(x1, y1), Quaternion.identity);
                            bedSpawned = true;
                        }
                        break;
                    case 3:
                        if (minAmount <= maxAmount)
                        {
                            minAmount += 1;
                            Instantiate(rugPrefab, new Vector3(x1, y1), Quaternion.identity);
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
}
