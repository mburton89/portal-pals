using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject macguffin;
    public TextMeshPro WinText;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("hi");
        if(other.gameObject == macguffin)
        {
            WinText.text = "YOU WIN!";
        }
    }
}