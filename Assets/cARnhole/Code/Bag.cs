using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    private bool _hasThrown;
    private bool _hasHitBoard;
    private bool _hasHitHole;
    private bool _gavePointsToPlayer;
    private int _pointsToGive;
    public bool isPlayer1;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _hasThrown = false;
        _hasHitBoard = false;
        _hasHitHole = false;
        _gavePointsToPlayer = false;
        _pointsToGive = 0;
        _rigidbody = GetComponent<Rigidbody>();
        InvokeRepeating(nameof(CheckMomentum), 0, 1);
    }

    public void Throw()
    {
        _hasThrown = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OnePoint") && !_hasHitBoard)
        {
            _hasHitBoard = true;
            _pointsToGive += 1;
        }
        else if (collision.gameObject.CompareTag("ThreePoints") && !_hasHitHole)
        {
            _hasHitHole = true;
            if (_hasHitBoard)
            {
                _pointsToGive += 2;
                if (_gavePointsToPlayer)
                {
                    CarnholeManager.Instance.AwardPointsForRound(isPlayer1, 2, false);
                }
            }
            else
            {
                _pointsToGive += 3;
            }
        }
        else if (collision.gameObject.CompareTag("NoPoints"))
        {
            if (_hasHitBoard && !_hasHitHole)
            {
                _pointsToGive -= 1;
                if (_gavePointsToPlayer)
                {
                    CarnholeManager.Instance.AwardPointsForRound(isPlayer1, -1, false);
                }
            }
        }
    }

    void CheckMomentum()
    {
        if (_hasThrown && _rigidbody.velocity.magnitude < 0.1f && !_gavePointsToPlayer)
        {
            _gavePointsToPlayer = true;
            CarnholeManager.Instance.AwardPointsForRound(isPlayer1, _pointsToGive, true);
        }
    }
}
