using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodable : MonoBehaviour
{
    public void Explode()
    {
        Instantiate(Resources.Load("Explosion") as GameObject, transform.position, transform.rotation, null);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<GrabbableObject>())
        {
            Explode();
        }

        if (collision.gameObject.GetComponent<Explodable>())
        {
            collision.gameObject.GetComponent<Explodable>().Explode();
        }
    }
}
