using UnityEngine;
using UnityEngine.UI;

public class LevelSelectNew : MonoBehaviour
{
    [SerializeField] private Button _level1;
    [SerializeField] private Button _level2;
    [SerializeField] private Button _level3;
    [SerializeField] private Button _level4;
    [SerializeField] private Button _back;

    [SerializeField] private GameObject _container;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _characterMenu;

    private void OnEnable()
    {
        _level1.onClick.AddListener(HandleLevel1Pressed);
        _level2.onClick.AddListener(HandleLevel2Pressed);
        _level3.onClick.AddListener(HandleLevel3Pressed);
        _level4.onClick.AddListener(HandleLevel4Pressed);
        _back.onClick.AddListener(HandleBackPressed);
    }

    void HandleLevel1Pressed()
    {
        PlayerPrefs.SetInt("levelToLoad", 1);
        ShowCharacterSelect();
    }

    void HandleLevel2Pressed()
    {
        PlayerPrefs.SetInt("levelToLoad", 2);
        ShowCharacterSelect();
    }

    void HandleLevel3Pressed()
    {
        PlayerPrefs.SetInt("levelToLoad", 3);
        ShowCharacterSelect();
    }

    void HandleLevel4Pressed()
    {
        PlayerPrefs.SetInt("levelToLoad", 4);
        ShowCharacterSelect();
    }

    void HandleBackPressed()
    {
        _container.SetActive(false);
        _mainMenu.SetActive(true);
    }

    void ShowCharacterSelect()
    {
        _container.SetActive(false);
        _characterMenu.SetActive(true);
    }
}
