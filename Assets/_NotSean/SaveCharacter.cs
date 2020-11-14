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
}
