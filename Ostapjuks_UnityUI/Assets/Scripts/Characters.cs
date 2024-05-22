using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Characters : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_InputField birthYearInputField;
    public TMP_Dropdown chooseCharacter;
    public TMP_Dropdown skinDropDown;
    public Sprite[] skins;
    public Image displayImage;
    public Button newCharacterBtn;

    private int currentYear = 2024;
    private string characterName;
    private string characterAge;
    private static Characters instance;

    private void Start()
    {
        if (nameInputField == null || birthYearInputField == null || chooseCharacter == null ||
            skinDropDown == null || skins == null || displayImage == null || newCharacterBtn == null)
        {
            Debug.LogError("One or more references are not assigned in the inspector");
            return;
        }

        PopulateDropdownWithSkins();
        skinDropDown.onValueChanged.AddListener(OnSkinSelected);
        nameInputField.onValueChanged.AddListener(OnInputFieldChanged);
        birthYearInputField.onValueChanged.AddListener(OnBirthYearChanged);
        birthYearInputField.onValueChanged.AddListener(OnInputFieldChanged);

        UpdateButtonState();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void PopulateDropdownWithSkins()
    {
        if (skins == null || skins.Length == 0)
        {
            Debug.LogError("Skins array is not assigned or empty");
            return;
        }

        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

        foreach (var skin in skins)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData
            {
                text = skin.name,
                image = skin
            };
            options.Add(option);
        }

        skinDropDown.ClearOptions();
        skinDropDown.AddOptions(options);
    }

    private void OnSkinSelected(int index)
    {
        if (skins != null && index >= 0 && index < skins.Length)
        {
            displayImage.sprite = skins[index];
        }
        else
        {
            Debug.LogWarning("Invalid skin index selected");
        }
    }

    private void OnBirthYearChanged(string input)
    {
        string newText = string.Empty;
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                newText += c;
            }
        }
        birthYearInputField.text = newText;
    }

    private void OnInputFieldChanged(string input)
    {
        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        bool isNameFilled = !string.IsNullOrEmpty(nameInputField.text);
        bool isBirthYearFilled = !string.IsNullOrEmpty(birthYearInputField.text);
        newCharacterBtn.interactable = isNameFilled && isBirthYearFilled;
    }

    public void SaveNewCharacter()
    {
        try
        {
            characterName = nameInputField.text;
            ConvertFirstBirthYear();
            Debug.Log(nameInputField.text + " " + birthYearInputField.text);
        }
        catch (Exception ex)
        {
            Debug.LogWarning("Error saving character: " + ex.Message);
        }
    }

    private void ConvertFirstBirthYear()
    {
        int birthYear = Convert.ToInt32(birthYearInputField.text);
        characterAge = (currentYear - birthYear).ToString();
    }

    public string GetCharacterName()
    {
        return characterName;
    }

    public string GetCharacterAge()
    {
        return characterAge;
    }
}
