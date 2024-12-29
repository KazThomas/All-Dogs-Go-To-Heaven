using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ObjSpawner
{
    GameObject SpawnObj(GameObject caller);
}

public class ObjectSpawner : MonoBehaviour, ObjSpawner
{
    [SerializeField] private int width, height;

    [SerializeField] private GameObject dogPrefab;
    [SerializeField] private GameObject bedPrefab;
    [SerializeField] private GameObject hooverPrefab;
    [SerializeField] private GameObject rugPrefab;

    [SerializeField] private List<GameObject> objects = new List<GameObject>();

    private int maxAmount = 2;

    private bool dogSpawned = false;
    private bool bedSpawned = false;

    public GameObject SpawnObj(GameObject caller)
    {
        GameObject newObj = null;
        for (int x1 = 0; x1 < width; x1++)
        {
            for (int y1 = 0; y1 < height; y1++)
            {
                int rand = Random.Range(0, 5);
                int minAmount = 1;
                
                switch (rand)
                {
                    case 0:
                        newObj = null;
                        //nothing spawns here
                        break;
                    case 1:
                        if (!dogSpawned)
                        {
                            newObj = Instantiate(dogPrefab, new Vector3(x1, y1), Quaternion.identity);
                            dogSpawned = true;
                            //dogPrefab = GameObject.FindGameObjectWithTag("Dog");
                        }
                        break;
                    case 2:
                        if (!bedSpawned)
                        {
                            newObj = Instantiate(bedPrefab, new Vector3(x1, y1), Quaternion.identity);
                            bedSpawned = true;
                            //bedPrefab = GameObject.FindGameObjectWithTag("Bed");
                        }
                        break;
                    case 3:
                        if (minAmount <= maxAmount)
                        {
                            minAmount += 1;
                            newObj = Instantiate(rugPrefab, new Vector3(x1, y1), Quaternion.identity);
                        }
                        break;
                    case 4:
                        if (minAmount <= maxAmount)
                        {
                            newObj = Instantiate(hooverPrefab, new Vector3(x1, y1), Quaternion.identity);
                            objects.Add(hooverPrefab);
                            minAmount += 1;
                        }
                        break;
                    default:
                        newObj = null; 
                        break;
                } 
            }
        }
        return newObj;
    }
}

