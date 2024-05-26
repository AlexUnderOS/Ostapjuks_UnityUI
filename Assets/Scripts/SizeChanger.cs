using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeChanger : MonoBehaviour
{
    public Slider heightSlider;
    public Slider widthSlider;

    public Slider widthSliderOutfit;
    public Slider heightSliderOutfit;

    public GameObject outfitObjContainer;

    public Image skinImg;
    private Image[] outfitImgs;

    private RectTransform rectTransform;
    private RectTransform[] outfitRectTransforms;

    private void Start()
    {
        rectTransform = skinImg.GetComponent<RectTransform>();

        heightSlider.minValue = 50;
        heightSlider.maxValue = 500;
        widthSlider.minValue = 50;
        widthSlider.maxValue = 500;

        heightSlider.value = rectTransform.sizeDelta.y;
        widthSlider.value = rectTransform.sizeDelta.x;

        heightSlider.onValueChanged.AddListener(OnHeightSliderValueChanged);
        widthSlider.onValueChanged.AddListener(OnWidthSliderValueChanged);
        heightSliderOutfit.onValueChanged.AddListener(OnHeightSliderValueChangedOutfit);
        widthSliderOutfit.onValueChanged.AddListener(OnWidthSliderValueChangedOutfit);

        StartCoroutine(CheckForNewImages());
    }

    private IEnumerator CheckForNewImages()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            GetOutfitImagesAndRects();
        }
    }

    private void GetOutfitImagesAndRects()
    {
        outfitImgs = outfitObjContainer.GetComponentsInChildren<Image>();
        outfitRectTransforms = new RectTransform[outfitImgs.Length];

        for (int i = 0; i < outfitImgs.Length; i++)
        {
            outfitRectTransforms[i] = outfitImgs[i].GetComponent<RectTransform>();
        }
    }

    private void OnHeightSliderValueChanged(float value)
    {
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, value);
    }

    private void OnWidthSliderValueChanged(float value)
    {
        rectTransform.sizeDelta = new Vector2(value, rectTransform.sizeDelta.y);
    }

    private void OnHeightSliderValueChangedOutfit(float value)
    {
        float scaleFactor = value / heightSliderOutfit.maxValue;

        DragAndDrop dragAndDrop = FindObjectOfType<DragAndDrop>();

        if (dragAndDrop != null)
        {
            GameObject selectedObj = dragAndDrop.GetSelectedObj();
            if (selectedObj != null)
            {
                RectTransform rt = selectedObj.GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(rt.sizeDelta.x, scaleFactor *
                    outfitObjContainer.GetComponent<RectTransform>().sizeDelta.y);
            }
            else
            {
                Debug.LogError("No object selected!");
            }
        }
        else
        {
            Debug.LogError("DragAndDrop script not found!");
        }
    }

    private void OnWidthSliderValueChangedOutfit(float value)
    {
        float scaleFactor = value / widthSliderOutfit.maxValue;

        DragAndDrop dragAndDrop = FindObjectOfType<DragAndDrop>();

        if (dragAndDrop != null)
        {
            GameObject selectedObj = dragAndDrop.GetSelectedObj();
            if (selectedObj != null)
            {
                RectTransform rt = selectedObj.GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(scaleFactor *
                outfitObjContainer.GetComponent<RectTransform>().sizeDelta.x, rt.sizeDelta.y);
            }
            else
            {
                Debug.LogError("No object selected!");
            }
        }
        else
        {
            Debug.LogError("DragAndDrop script not found!");
        }
    }
}
