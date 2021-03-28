using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenuTwo : MonoBehaviour
{
    public static PauseMenuTwo Instance;
    public GameObject container;

    public Button mainMenuButton;
    public Button restartButton;
    public Button resumeButton;

    [HideInInspector] public bool isActive;

    void Awake()
    {
        Instance = this;
        isActive = false;
    }

    private void OnEnable()
    {
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        restartButton.onClick.AddListener(RestartLevel);
        resumeButton.onClick.AddListener(Resume);
    }

    private void OnDisable()
    {
        mainMenuButton.onClick.RemoveListener(GoToMainMenu);
        restartButton.onClick.RemoveListener(RestartLevel);
        resumeButton.onClick.RemoveListener(Resume);
    }

    public void Activate()
    {
        FindObjectOfType<RigidbodyFirstPersonController>().enabled = false;
        isActive = true;
        container.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Resume()
    {
        FindObjectOfType<RigidbodyFirstPersonController>().enabled = true;
        isActive = false;
        container.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
