using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public static ShipSpawner Instance;

    [SerializeField] private Ship _shipPrefab;

    [SerializeField] private Transform _topLeft;
    [SerializeField] private Transform _midLeft;
    [SerializeField] private Transform _bottomLeft;
    [SerializeField] private Transform _topRight;
    [SerializeField] private Transform _midRight;
    [SerializeField] private Transform _bottomRight;

    private float _startingShipSpeed;
    private float _currentShipSpeed;

    public enum SpawnPosition
    {
        TopLeft,
        MidLeft,
        BottomLeft,
        TopRight,
        MidRight,
        BottomRight,
    }

    [HideInInspector] public int activeShips;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _startingShipSpeed = 20f;
        _currentShipSpeed = _startingShipSpeed;
        SpawnRandomScenario();
    }

    public void SpawnRandomScenario()
    {
        int rand = Random.Range(0, 4);

        if (rand == 0)
        {
            SpawnShip(SpawnPosition.TopLeft);
            SpawnShip(SpawnPosition.MidRight);
            SpawnShip(SpawnPosition.BottomLeft);
        }
        else if (rand == 1)
        {
            SpawnShip(SpawnPosition.TopRight);
            SpawnShip(SpawnPosition.MidLeft);
            SpawnShip(SpawnPosition.BottomRight);
        }
        else if (rand == 2)
        {
            SpawnShip(SpawnPosition.TopRight);
            SpawnShip(SpawnPosition.MidRight);
            SpawnShip(SpawnPosition.BottomRight);
        }
        else if (rand == 3)
        {
            SpawnShip(SpawnPosition.TopLeft);
            SpawnShip(SpawnPosition.MidLeft);
            SpawnShip(SpawnPosition.BottomLeft);
        }
    }

    void SpawnShip(SpawnPosition spawnPosition)
    {
        Ship ship = new Ship();

        if (spawnPosition == SpawnPosition.TopLeft)
        {
            ship = Instantiate(_shipPrefab, _topLeft.position, _topLeft.rotation, null);
            ship.GetComponent<Rigidbody>().AddForce(Vector3.right * _currentShipSpeed);
        }
        else if (spawnPosition == SpawnPosition.MidLeft)
        {
            ship = Instantiate(_shipPrefab, _midLeft.position, _midLeft.rotation, null);
            ship.GetComponent<Rigidbody>().AddForce(Vector3.right * _currentShipSpeed);
        }
        else if (spawnPosition == SpawnPosition.BottomLeft)
        {
            ship = Instantiate(_shipPrefab, _bottomLeft.position, _bottomLeft.rotation, null);
            ship.GetComponent<Rigidbody>().AddForce(Vector3.right * _currentShipSpeed);
        }
        else if (spawnPosition == SpawnPosition.TopRight)
        {
            ship = Instantiate(_shipPrefab, _topRight.position, _topRight.rotation, null);
            ship.GetComponent<Rigidbody>().AddForce(Vector3.left * _currentShipSpeed);
        }
        else if (spawnPosition == SpawnPosition.MidRight)
        {
            ship = Instantiate(_shipPrefab, _midRight.position, _midRight.rotation, null);
            ship.GetComponent<Rigidbody>().AddForce(Vector3.left * _currentShipSpeed);
        }
        else if (spawnPosition == SpawnPosition.BottomRight)
        {
            ship = Instantiate(_shipPrefab, _bottomRight.position, _bottomRight.rotation, null);
            ship.GetComponent<Rigidbody>().AddForce(Vector3.left * _currentShipSpeed);
        }

        activeShips++;
    }

    public void HandleShipDestroyed()
    {
        activeShips--;
        if (activeShips == 0)
        {
            _currentShipSpeed = _currentShipSpeed + 5f;
            SpawnRandomScenario();
        }
    }
}
