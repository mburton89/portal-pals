using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    private void Awake()
    {
        if (PlayerPrefs.GetInt("hasStartedGame") != 1)
        {
            PlayerPrefs.SetInt("hasStartedGame", 1);
            PlayerPrefs.SetInt("Dean", 0);
            PlayerPrefs.SetInt("Maddie", 0);
            PlayerPrefs.SetInt("Layne", 0);
            PlayerPrefs.SetInt("Austan", 0);
            PlayerPrefs.SetInt("Beck", 0);
            PlayerPrefs.SetInt("Liam", 0);
            PlayerPrefs.SetInt("Matt", 0);
            PlayerPrefs.SetInt("Sean", 0);
            PlayerPrefs.SetInt("Aaron", 0);
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
    }

    void HandleDeanPressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 0);
    }

    void HandleMaddiePressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 1);
    }

    void HandleLaynePressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 2);
    }

    void HandleAustanPressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 3);
    }

    void HandleBeckPressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 4);
    }

    void HandleLiamPressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 5);
    }

    void HandleMattPressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 6);
    }

    void HandleSeanPressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 7);
    }

    void HandleAaronPressed()
    {
        PlayerPrefs.SetInt("PlayerIndex", 8);
    }
}
