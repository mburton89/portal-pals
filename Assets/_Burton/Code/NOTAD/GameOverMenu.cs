﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class GameOverMenu : MonoBehaviour
{
    public static GameOverMenu Instance;
    public GameObject container;

    public Image bread1;
    public Image bread2;
    public Image bread3;

    public Sprite fullBread;

    public Button mainMenuButton;
    public Button restartButton;
    public Button nextLevelButton;

    [HideInInspector] public bool isActive;

    public TextMeshProUGUI gameOverText;

    public AudioSource maggotyBread1AudioSource;
    public AudioSource maggotyBread2AudioSource;
    public AudioSource maggotyBread3AudioSource;
    public AudioSource textAudioSource;

    public List<AudioClip> endgameAudioClips;
    public AudioSource endgameAudioSource;

    void Awake()
    {
        Instance = this;
        isActive = false;
    }

    private void OnEnable()
    {
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        restartButton.onClick.AddListener(RestartLevel);
        nextLevelButton.onClick.AddListener(GoToNextLevel);
    }

    private void OnDisable()
    {
        mainMenuButton.onClick.RemoveListener(GoToMainMenu);
        restartButton.onClick.RemoveListener(RestartLevel);
        nextLevelButton.onClick.RemoveListener(GoToNextLevel);
    }

    public void Activate(int numberOfBreads)
    {
        if (numberOfBreads > 0)
        {
            int levelUnlocked = SceneManager.GetActiveScene().buildIndex + 1;
            string levelUnlockedString = "level" + levelUnlocked;
            PlayerPrefs.SetInt(levelUnlockedString, 1);
        }

        if (numberOfBreads > PlayerPrefs.GetInt(SceneManager.GetActiveScene().buildIndex.ToString()))
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().buildIndex.ToString(), numberOfBreads);
        }

        StartCoroutine(ShowResults(numberOfBreads));
    }

    private IEnumerator ShowResults(int numberOfBreads)
    {
        if (FindObjectOfType<RigidbodyFirstPersonController>())
        {
            FindObjectOfType<RigidbodyFirstPersonController>().enabled = false;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isActive = true;

        if (PauseMenuTwo.Instance.isActive)
        {
            PauseMenuTwo.Instance.Resume();
        }

        container.SetActive(true);

        yield return new WaitForSeconds(1);




        //yield return new WaitForSeconds(.5f);
        if (numberOfBreads >= 1)
        {
            bread1.sprite = fullBread;
            gameOverText.SetText("1 maggoty bread");
        }
        bread1.gameObject.SetActive(true);
        bread1.transform.DOShakeScale(.3f, 1, 10, 90, true);
        maggotyBread1AudioSource.Play();
        yield return new WaitForSeconds(.5f);
        if (numberOfBreads >= 2)
        {
            bread2.sprite = fullBread;
            gameOverText.SetText("2 maggoty breads");
        }
        bread2.gameObject.SetActive(true);
        bread2.transform.DOShakeScale(.3f, 1, 10, 90, true);
        maggotyBread2AudioSource.Play();
        yield return new WaitForSeconds(.5f);
        if (numberOfBreads >= 3)
        {
            bread3.sprite = fullBread;
            gameOverText.SetText("3 maggoty breads");
        }
        bread3.gameObject.SetActive(true);
        bread3.transform.DOShakeScale(.3f, 1, 10, 90, true);
        maggotyBread3AudioSource.Play();
        yield return new WaitForSeconds(.5f);
        gameOverText.gameObject.SetActive(true);
        gameOverText.transform.localScale = new Vector3(10, 10);
        gameOverText.transform.DOScale(1, .15f);
        yield return new WaitForSeconds(.15f);
        gameOverText.transform.DOShakeScale(.3f, 1, 10, 90, true);
        textAudioSource.Play();

        yield return new WaitForSeconds(.5f);
        endgameAudioSource.clip = endgameAudioClips[numberOfBreads];
        endgameAudioSource.Play();
        mainMenuButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        if (SceneManager.GetActiveScene().buildIndex != 6 && numberOfBreads > 0)
        {
            nextLevelButton.gameObject.SetActive(true);
        }
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
