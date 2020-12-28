using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoostGun : MonoBehaviour
{
    [SerializeField] private AudioSource _shoostSound;
    [SerializeField] private GameObject _firingPoint;
    [SerializeField] private HoldButton _shoostButton;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _shoostForce;

    public GameObject m_shotPrefab;

    private void OnEnable()
    {
        _shoostButton.onPointerDown.AddListener(ShoostLaser);
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShoostLaser();
        }
        if (Input.GetMouseButtonDown(1))
        {
            ShoostBullet();
        }
    }

    void ShoostLaser()
    {
        GameObject go = GameObject.Instantiate(m_shotPrefab, _firingPoint.transform.position, _firingPoint.transform.rotation) as GameObject;

        _shoostSound.Play();

        RaycastHit[] hits;
        hits = Physics.RaycastAll(_firingPoint.transform.position, transform.TransformDirection(Vector3.forward), Mathf.Infinity);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit raycastHit = hits[i];
            if (raycastHit.collider.gameObject.GetComponent<Ship>())
            {
                raycastHit.collider.gameObject.GetComponent<Ship>().Splode();
            }
            else if (raycastHit.collider.gameObject.GetComponent<Astronaut>())
            {
                raycastHit.collider.gameObject.GetComponent<Astronaut>().Splode();
            }
        }
    }

    void ShoostBullet()
    {
        Quaternion rotation = new Quaternion(0, 0, 90, 0);
        GameObject bullet = Instantiate(_bulletPrefab, _firingPoint.transform.position, transform.rotation , null);
        bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * _shoostForce);
    }
}
