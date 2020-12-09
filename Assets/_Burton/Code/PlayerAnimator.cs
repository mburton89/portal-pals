﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private List<Sprite> DeanSprites;
    [SerializeField] private List<Sprite> MaddieSprites;
    [SerializeField] private List<Sprite> LayneSprites;
    [SerializeField] private List<Sprite> AustanSprites;
    [SerializeField] private List<Sprite> BeccSprites;
    [SerializeField] private List<Sprite> LiamSprites;
    [SerializeField] private List<Sprite> MattSprites;
    [SerializeField] private List<Sprite> SeanSprites;
    [SerializeField] private List<Sprite> AaronSprites;

    private SpriteRenderer _spriteRenderer;
    private List<List<Sprite>> characterSpriteLists;
    private List<Sprite> currentSpriteList;

    [SerializeField] private float _frameRate;

    void Start()
    {
        characterSpriteLists = new List<List<Sprite>>();
        currentSpriteList = new List<Sprite>();
        characterSpriteLists.Add(DeanSprites);
        characterSpriteLists.Add(MaddieSprites);
        characterSpriteLists.Add(LayneSprites);
        characterSpriteLists.Add(AustanSprites);
        characterSpriteLists.Add(BeccSprites);
        characterSpriteLists.Add(LiamSprites);
        characterSpriteLists.Add(MattSprites);
        characterSpriteLists.Add(SeanSprites);
        characterSpriteLists.Add(AaronSprites);

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            currentSpriteList = characterSpriteLists[Random.Range(0, characterSpriteLists.Count)];
        }
        else
        {
            currentSpriteList = characterSpriteLists[PlayerPrefs.GetInt("PlayerIndex")];
        }

        _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        for (int i = 0; i < currentSpriteList.Count; i++)
        {
            _spriteRenderer.sprite = currentSpriteList[i];
            yield return new WaitForSeconds(_frameRate);
        }

        StartCoroutine(Animate());
    }
}
