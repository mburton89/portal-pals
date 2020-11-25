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

    private void Awake()
    {
        _initialYPosition = door.transform.position.y;
        _doorMoveDistance = 5;
        _doorMoveDuration = 1;
    }

    void OnTriggerEnter(Collider col)
    {
        if (isOpened == false)
        {
            isOpened = true;
            door.transform.DOMoveY(_doorMoveDistance, _doorMoveDuration);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isOpened == true)
        {
            isOpened = false;
            //door.transform.position -= new Vector3(0, 4, 0);

            door.transform.DOMoveY(_initialYPosition, _doorMoveDuration);
        }
    }
}
