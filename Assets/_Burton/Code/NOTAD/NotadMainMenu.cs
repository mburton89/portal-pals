using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class NotadMainMenu : MonoBehaviour
{
    public static NotadMainMenu Instance;

    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;
    public Button level5Button;

    public List<GameObject> level1MaggotyBreads;
    public List<GameObject> level2MaggotyBreads;
    public List<GameObject> level3MaggotyBreads;
    public List<GameObject> level4MaggotyBreads;
    public List<GameObject> level5MaggotyBreads;

    public TextMeshProUGUI titleWhite;
    public TextMeshProUGUI titleBlack;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        level2Button.gameObject.SetActive(false);
        level3Button.gameObject.SetActive(false);
        level4Button.gameObject.SetActive(false);
        level5Button.gameObject.SetActive(false);
        DisplayLevelStatus();
        DisplayBreads();

        level1Button.onClick.AddListener(LoadLevel1);
        level2Button.onClick.AddListener(LoadLevel2);
        level3Button.onClick.AddListener(LoadLevel3);
        level4Button.onClick.AddListener(LoadLevel4);
        level5Button.onClick.AddListener(LoadLevel5);

        StartCoroutine(ShowTitle());
    }

    void DisplayLevelStatus()
    {
        if (PlayerPrefs.GetInt("level2") == 1)
        {
            level2Button.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("level3") == 1)
        {
            level3Button.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("level4") == 1)
        {
            level4Button.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("level5") == 1)
        {
            level5Button.gameObject.SetActive(true);
        }
    }

    void DisplayBreads()
    {
        if (PlayerPrefs.GetInt("1") > 0)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("1"); i++)
            {
                level1MaggotyBreads[i].SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("2") > 0)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("2"); i++)
            {
                level2MaggotyBreads[i].SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("3") > 0)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("3"); i++)
            {
                level3MaggotyBreads[i].SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("4") > 0)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("4"); i++)
            {
                level4MaggotyBreads[i].SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("5") > 0)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("5"); i++)
            {
                level5MaggotyBreads[i].SetActive(true);
            }
        }
    }

    private IEnumerator ShowTitle()
    {
        titleWhite.color = Color.clear;
        titleBlack.color = Color.clear;
        yield return new WaitForSeconds(.5f);
        titleWhite.DOColor(Color.white, 1.5f);
        yield return new WaitForSeconds(1.25f);
        titleBlack.DOColor(Color.black, .25f);
    }

    void LoadLevel1(){SceneManager.LoadScene(1);}
    void LoadLevel2(){SceneManager.LoadScene(2);}
    void LoadLevel3(){SceneManager.LoadScene(3);}
    void LoadLevel4(){SceneManager.LoadScene(4);}
    void LoadLevel5(){SceneManager.LoadScene(5);}
}
