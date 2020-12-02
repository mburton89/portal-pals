using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] 
    GameObject door;

    private float _doorMoveDistance;
    private float _initialYPosition;
    private float _doorMoveDuration;

    bool isOpened = false;

    private List<GameObject> objectsOnTrigger;

    private void Awake()
    {
        objectsOnTrigger = new List<GameObject>();
        _initialYPosition = door.transform.position.y;
        _doorMoveDistance = 2.2f;
        _doorMoveDuration = 0.5f;
    }

    void OnTriggerEnter(Collider col)
    {
        objectsOnTrigger.Add(col.gameObject);

        if (isOpened == false)
        {
            isOpened = true;
            door.transform.DOMoveY(_initialYPosition + _doorMoveDistance, _doorMoveDuration);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        objectsOnTrigger.Remove(other.gameObject);

        if (isOpened == true && objectsOnTrigger.Count <= 0)
        {
            isOpened = false;
            door.transform.DOMoveY(_initialYPosition, _doorMoveDuration);
        }
    }
}
