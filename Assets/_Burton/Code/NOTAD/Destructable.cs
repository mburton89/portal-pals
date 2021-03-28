using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public List<GameObject> thingsThatCanKillMe;
    private bool _hasSploded = false;

    private void OnTriggerEnter(Collider other)
    {
        //if (thingsThatCanKillMe.Contains(other.gameObject) || other.gameObject.GetComponent<Dwarf>() || other.tag == "Ground") 
        //{
        //    Splode();
        //}
        if (other.gameObject != gameObject)
        {
            print(other.gameObject.name);
            Splode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (thingsThatCanKillMe.Contains(collision.gameObject) || collision.gameObject.GetComponent<Dwarf>() || collision.gameObject.tag == "Ground")
        //{
        //    Splode();
        //}
        //if (collision.gameObject != gameObject)
        //{
        //    print(collision.gameObject.name);
        //    Splode();
        //}
        if (collision.gameObject.GetComponent<Dwarf>())
        {
            Splode();
        }
    }

    public void Splode()
    {
        if (_hasSploded) return;

        if (GetComponent<Orc>())
        {
            NotadGameManager.Instance.HandleOrcDestroyed();
        }

        Instantiate(Resources.Load("Explosion") as GameObject, transform.position, transform.rotation, null);
        _hasSploded = true;
        Destroy(gameObject);
    }
}
