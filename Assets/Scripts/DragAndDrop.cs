using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rTransform;
    private Canvas canv;
    private Vector2 offset;

    void Start()
    {
        canv = FindAnyObjectByType<Canvas>();
        rTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canv.transform as RectTransform, eventData.position, canv.worldCamera, out offset);
        offset = (Vector2)rTransform.localPosition - offset;
        Debug.Log("Clicked on draggable object!");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Started dragging!");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canv.transform as RectTransform, eventData.position, canv.worldCamera, out localPoint))
        {
            rTransform.localPosition = localPoint + offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Object dropped, dragging stopped!");
    }
}
