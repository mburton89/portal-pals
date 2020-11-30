using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class SceneManagerManager : MonoBehaviour
{
    private Transform _player;
    private float _minY;

    void Awake()
    {
        _player = FindObjectOfType<RigidbodyFirstPersonController>().transform;
        _minY = -5f;
    }

    void Start()
    {
        InvokeRepeating("CheckPlayerBoundaries", 0f, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RigidbodyFirstPersonController>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void CheckPlayerBoundaries()
    {
        if (_player.transform.position.y < _minY)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
