using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class TransitionAnimation : MonoBehaviour
{
    public float speed = 10f;
    public GameObject panel;

    void Update()
    {
        MoveingUp();
    }

    public void MoveingUp()
    {
        //panel.SetActive(true);
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, speed * Time.deltaTime));
        transform.rotation *= rotation;
        transform.Translate(Vector3.up * speed * Time.deltaTime);

    }

    public void FadePanel()
    {
        Image imageComponent = panel.GetComponent<Image>();

        Color currentColor = imageComponent.color;
        currentColor.a -= speed * Time.deltaTime;
        imageComponent.color = currentColor;

        if (currentColor.a < 0)
        {
            currentColor.a = 0;
        }
    }


}
