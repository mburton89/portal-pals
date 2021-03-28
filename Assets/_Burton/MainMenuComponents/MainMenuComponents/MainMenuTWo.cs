using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuTWo : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private GameObject _creditsMenu;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(HandleStartPressed);
        _creditsButton.onClick.AddListener(HandleCreditsPressed);
    }

    void HandleStartPressed()
    {
        SceneManager.LoadScene(1);
    }

    void HandleCreditsPressed()
    {
        _creditsMenu.SetActive(true);
    }
}
