using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tv : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public List<Sprite> sprites;
    public float frameRate;
    private int _index = 0;

    void Start()
    {
        StartCoroutine(Loop());
    }

    private IEnumerator Loop()
    {
        yield return new WaitForSeconds(frameRate);
        _index++;

        if (_index > sprites.Count - 1)
        {
            _index = 0;
        }

        spriteRenderer.sprite = sprites[_index];

        StartCoroutine(Loop());
    }
}
