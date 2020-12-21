using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private Explodable _explodable;

    void Awake()
    {
        _explodable = GetComponent<Explodable>();
    }

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnDestroy()
    {
        _explodable.Explode();
    }
}
