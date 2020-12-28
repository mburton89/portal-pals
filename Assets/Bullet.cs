using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ship>())
        {
            collision.gameObject.GetComponent<Ship>().DelaySplode();
            Instantiate(Resources.Load("Explosion") as GameObject, transform.position, transform.rotation, null);
            Destroy(gameObject);
        }
    }
}
