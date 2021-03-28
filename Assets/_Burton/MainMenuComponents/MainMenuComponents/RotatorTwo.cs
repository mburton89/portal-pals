using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorTwo : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    void FixedUpdate()
    {
        transform.Rotate(direction * speed);
    }
}
