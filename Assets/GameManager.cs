using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float _score;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _gameOverContainer;
    [SerializeField] private Button _restart;

    private void Awake()
    {
        _score = 0;
        UpdateScoreUI();
        Instance = this;
    }

    private void OnEnable()
    {
        _restart.onClick.AddListener(Restart);
    }

    private void OnDisable()
    {
        _restart.onClick.RemoveListener(Restart);
    }

    public void HandleShipDestroyed()
    {
        _score = _score + 10;
        UpdateScoreUI();
    }

    public void HandleAstronautDestroyed()
    {
        _score = _score + 5;
        UpdateScoreUI();
    }

    public void GameOver()
    {
        _gameOverContainer.SetActive(true);
    }

    void UpdateScoreUI()
    {
        _scoreText.SetText(_score.ToString());
    }

    void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
