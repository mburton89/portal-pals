using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrower : MonoBehaviour
{
    [SerializeField] private GrabbableObject _grabbedObjectPrefab;
    private GrabbableObject _grabbedObject;
    [SerializeField] private HoldButton _holdButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GrabObject();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            FlingObject();
        }
    }

    private void OnEnable()
    {
        _holdButton.onPointerDown.AddListener(GrabObject);
        _holdButton.onPointerUp.AddListener(FlingObject);
    }

    private void OnDisable()
    {
        _holdButton.onPointerDown.RemoveListener(GrabObject);
        _holdButton.onPointerUp.RemoveListener(FlingObject);
    }

    void GrabObject()
    {
        _grabbedObject = Instantiate(_grabbedObjectPrefab, transform.position, transform.rotation, null);
        _grabbedObject.Grab(this);
    }

    void FlingObject()
    {
        if (_grabbedObject != null)
        {
            _grabbedObject.Fling();
        }
        Reset();
    }

    public void Reset()
    {
        _grabbedObject = null;
    }
}
