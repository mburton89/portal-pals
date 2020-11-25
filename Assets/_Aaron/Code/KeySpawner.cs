using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public GameObject key;
    public Transform spawnpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Instantiate(key, spawnpoint.position, spawnpoint.rotation, spawnpoint);
            print("BallGetCar");
        }
    }
}
