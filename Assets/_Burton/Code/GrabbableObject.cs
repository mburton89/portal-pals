using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    private ObjectGrabber _controller;
    private ObjectThrower _throwController;
    private Rigidbody _rb;

    private Vector3 _previousPosition;
    private Vector3 _currentPosition;

    private Vector3 _previousAngles;
    private Vector3 _currentAngles;

    private void Update()
    {
        _previousPosition = _currentPosition;
        _currentPosition = transform.position;

        _previousAngles = _currentAngles;
        _currentAngles = transform.eulerAngles;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Portal>())
        {
            LetGo();
        }
    }

    public void Grab(ObjectGrabber controller)
    {
        _controller = controller;
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
        transform.SetParent(_controller.transform);
        transform.localPosition = new Vector3(0, -0.4f, 0);
        transform.localEulerAngles = Vector3.zero;
    }

    public void Grab(ObjectThrower controller)
    {
        _throwController = controller;
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
        if (_controller != null)
        {
            transform.SetParent(_controller.transform);
        }
        if (_throwController != null)
        {
            transform.SetParent(_throwController.transform);
        }
        transform.localPosition = new Vector3(0, -0.4f, 0);
        transform.localEulerAngles = Vector3.zero;
    }

    public void LetGo()
    {
        if (GetComponent<Bag>())
        {
            GetComponent<Bag>().Throw();
        }

        if (_controller != null)
        {
            _controller.Reset();
        }
        if (_throwController != null)
        {
            _throwController.Reset();
        }
        _rb.isKinematic = false;
        _rb.transform.SetParent(null);
    }

    public void Fling()
    {
        LetGo();
        _rb.AddForce((_currentPosition - _previousPosition) * 4000);
        _rb.AddTorque((_currentAngles - _previousAngles) * 4000);
    }
}
