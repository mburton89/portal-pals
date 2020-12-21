using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoostGun : MonoBehaviour
{
    public AudioSource shoostSound;
    public GameObject firingPoint;
    public HoldButton shoostButton;

    private void OnEnable()
    {
        shoostButton.onPointerDown.AddListener(Shoost);
    }

    void LateUpdate()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Shoost();
        //}
    }

    void Shoost()
    {
        RaycastHit raycastHit;
        shoostSound.Play();
        if (Physics.Raycast(firingPoint.transform.position, transform.TransformDirection(Vector3.forward), out raycastHit, Mathf.Infinity) && raycastHit.collider.gameObject.GetComponent<Explodable>())
        {
            raycastHit.collider.gameObject.GetComponent<Explodable>().Explode();
        }
    }
}
