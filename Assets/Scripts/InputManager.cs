using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_InputField ageInputField;
    public Image userImage;
    private string characterAge;


    public void OnSubmitButton()
    {
        string name = nameInputField.text;
        string age = ageInputField.text;
        ConvertFirstBirthYear();

        PlayerPrefs.SetString("PlayerName", name);
        PlayerPrefs.SetString("PlayerAge", characterAge);

        string spriteName = userImage.sprite.name;
        PlayerPrefs.SetString("PlayerImageName", spriteName);

    }


    private void ConvertFirstBirthYear()
    {
        int birthYear = Convert.ToInt32(ageInputField.text);
        characterAge = (2024 - birthYear).ToString();
    }
}
