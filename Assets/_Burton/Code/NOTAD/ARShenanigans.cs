using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARShenanigans : MonoBehaviour
{
    public Button velocityButton; 

    void Start()
    {
        velocityButton.onClick.AddListener(ChangeDwarfVelocity);
    }

    void ChangeDwarfVelocity()
    {
        Rigidbody rigidbody = FindObjectOfType<Dwarf>().GetComponent<Rigidbody>();
        rigidbody.velocity = -rigidbody.velocity;
    }
}
