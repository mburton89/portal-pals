using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagSpawner : MonoBehaviour
{
    public static BagSpawner Instance;

    public Transform p1BagSpawnPoint;
    public Transform p2BagSpawnPoint;
    public Bag _p1BagPrefab;
    public Bag _p2BagPrefab;

    void Awake()
    {
        Instance = this;
    }

    public void SpawnBags()
    {
        for (int i = 0; i < 4; i++)
        {
            Bag bag = Instantiate(_p1BagPrefab, p1BagSpawnPoint.position, p1BagSpawnPoint.rotation, null) as Bag;
            bag.isPlayer1 = true;
        }

        for (int i = 0; i < 4; i++)
        {
            Bag bag = Instantiate(_p2BagPrefab, p2BagSpawnPoint.position, p2BagSpawnPoint.rotation, null) as Bag;
            bag.isPlayer1 = false;
        }
    }
}
