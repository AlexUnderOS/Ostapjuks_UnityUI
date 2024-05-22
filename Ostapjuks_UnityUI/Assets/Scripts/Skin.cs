using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    public TMP_Dropdown skinDropDown;
    public Sprite[] skins;
    public Image displayImage;

    private void Start()
    {
        PopulateDropdownWithSkins();
        skinDropDown.onValueChanged.AddListener(OnSkinSelected);
    }

    private void PopulateDropdownWithSkins()
    {
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

        foreach (var skin in skins)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = skin.name;
            option.image = skin;
            options.Add(option);
        }

        skinDropDown.AddOptions(options);
    }

    private void OnSkinSelected(int index)
    {
        if (index >= 0 && index < skins.Length)
        {
            displayImage.sprite = skins[index];
        }
    }
}
