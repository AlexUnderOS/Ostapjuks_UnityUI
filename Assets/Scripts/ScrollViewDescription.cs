using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewDescription : MonoBehaviour
{
    public TMP_Text scrollText;
    public TMP_Dropdown dropdown;

    [TextArea]
    public string[] discriptions;
    public void Start()
    {
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private void OnDropdownValueChanged(int index)
    {
        scrollText.text = discriptions[index];
    }
}
