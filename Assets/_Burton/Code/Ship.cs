using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private GameObject _pilotPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ship>())
        {
            Splode();
        }
    }

    public void Splode()
    {
        ShipSpawner.Instance.HandleShipDestroyed();
        GameManager.Instance.HandleShipDestroyed();

        GameObject pilot = Instantiate(_pilotPrefab, transform.position, transform.rotation, null);

        float randXF = Random.Range(-1f, 1f);
        float randYF = Random.Range(-1f, 1f);
        float randZF = Random.Range(-1f, 1f);
        float randXT = Random.Range(-1f, 1f);
        float randYT = Random.Range(-1f, 1f);
        float randZT = Random.Range(-1f, 1f);
        float randForce = Random.Range(5f, 30f);
        float randTorque = Random.Range(-30f, 30f);

        pilot.GetComponent<Rigidbody>().AddForce(new Vector3(randXF, randYF, randZF) * randForce);
        pilot.GetComponent<Rigidbody>().AddTorque(new Vector3(randXT, randYT, randZT) * randTorque);
        Instantiate(Resources.Load("Explosion") as GameObject, transform.position, transform.rotation, null);
        Destroy(gameObject);
    }

    public void DelaySplode()
    {
        StartCoroutine(DelaySplodeCo());
    }

    private IEnumerator DelaySplodeCo()
    {
        yield return new WaitForSeconds(3f);
        Splode();
    }
}
