using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

public class DragAndDropContainer : MonoBehaviour
{
    private RectTransform rTransform;

    void Start()
    {
        rTransform = GetComponent<RectTransform>();
    }

    public void DuplicateObject(GameObject original)
    {
        GameObject duplicate = Instantiate(original, gameObject.transform);
        RectTransform duplicateRectTransform = duplicate.GetComponent<RectTransform>();

        duplicateRectTransform.localPosition = rTransform.localPosition + new Vector3(10, -10, 0);

        Button buttonComponent = duplicate.GetComponent<Button>();
        if (buttonComponent != null)
        {
            Destroy(buttonComponent);
        }

        duplicateRectTransform.sizeDelta = original.GetComponent<RectTransform>().sizeDelta;
        duplicateRectTransform.localScale = Vector3.one;

        Debug.Log("Object duplicated!");

        duplicate.AddComponent<DragAndDrop>();
    }
}
