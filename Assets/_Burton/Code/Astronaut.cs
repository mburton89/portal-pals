using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            GetComponent<Rigidbody>().isKinematic = false;
            print("ouch");
        }
    }

    public void Splode()
    {
        GameManager.Instance.HandleAstronautDestroyed();
        Instantiate(Resources.Load("Explosion") as GameObject, transform.position, transform.rotation, null);
        Destroy(gameObject);
    }
}
