using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System;

public class DisplayManager : MonoBehaviour
{
    public TMP_Text displayText;
    public Image userImage;


    void Start()
    {
        string name = PlayerPrefs.GetString("PlayerName");
        string age = PlayerPrefs.GetString("PlayerAge");
        string spriteName = PlayerPrefs.GetString("PlayerImageName");


        displayText.text = "Pick a style for "+name+", he turned "+age+" today, great guy!";

        Sprite sprite = Resources.Load<Sprite>(spriteName);
        if (sprite != null)
        {
            userImage.sprite = sprite;
        }
        else
        {
            Debug.LogError("Sprite not found: " + spriteName);
        }
    }
}
