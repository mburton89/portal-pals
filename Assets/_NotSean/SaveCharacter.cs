using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveCharacter : MonoBehaviour
{
    public Button Dean;
    public Button Maddie;
    public Button Layne;
    public Button Austan;
    public Button Beck;
    public Button Liam;
    public Button Matt;
    public Button Sean;
    public Button Aaron;
    public Button Mallow;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("hasStartedGame") != 1)
        {
            PlayerPrefs.SetInt("hasStartedGame", 1);
        }
    }

    private void OnEnable()
    {
        Dean.onClick.AddListener(HandleDeanPressed);
        Maddie.onClick.AddListener(HandleMaddiePressed);
        Layne.onClick.AddListener(HandleLaynePressed);
        Austan.onClick.AddListener(HandleAustanPressed);
        Beck.onClick.AddListener(HandleBeckPressed);
        Liam.onClick.AddListener(HandleLiamPressed);
        Matt.onClick.AddListener(HandleMattPressed);
        Sean.onClick.AddListener(HandleSeanPressed);
        Aaron.onClick.AddListener(HandleAaronPressed);
        Mallow.onClick.AddListener(HandleMallowPressed);
    }

    void HandleDeanPressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 0);
        LoadNextScene();
    }

    void HandleMaddiePressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 1);
        LoadNextScene();
    }

    void HandleLaynePressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 2);
        LoadNextScene();
    }

    void HandleAustanPressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 3);
        LoadNextScene();
    }

    void HandleBeckPressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 4);
        LoadNextScene();
    }

    void HandleLiamPressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 5);
        LoadNextScene();
    }

    void HandleMattPressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 6);
        LoadNextScene();
    }

    void HandleSeanPressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 7);
        LoadNextScene();
    }

    void HandleAaronPressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 8);
        LoadNextScene();
    }

    void HandleMallowPressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 9);
        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("levelToLoad"));
    }
}
