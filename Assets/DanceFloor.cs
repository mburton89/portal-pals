using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DanceFloor : MonoBehaviour
{
    [SerializeField] private float _closeDistance;
    [SerializeField] private float _farDistance;
    [SerializeField] private float _secondsToMoveOut;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private List<Transform> _sprites;

    private void Start()
    {
        StartCoroutine(MoveInAndOut());
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * _rotationSpeed);
    }

    private IEnumerator MoveInAndOut()
    {
        foreach (Transform sprite in _sprites)
        {
            sprite.DOLocalMoveZ(_farDistance, _secondsToMoveOut).SetEase(Ease.InOutQuad);
        }

        yield return new WaitForSeconds(_secondsToMoveOut);

        foreach (Transform sprite in _sprites)
        {
            sprite.DOLocalMoveZ(_closeDistance, _secondsToMoveOut).SetEase(Ease.InOutQuad);
        }

        yield return new WaitForSeconds(_secondsToMoveOut);
        StartCoroutine(MoveInAndOut());
    }
}
