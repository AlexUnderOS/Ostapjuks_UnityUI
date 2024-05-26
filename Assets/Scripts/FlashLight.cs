using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    private Transform objectToMove;
    public float moveSpeed = 35f;

    private void Start()
    {
        objectToMove = GetComponent<Transform>();
    }


    private void Update()
    {
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = objectToMove.position.z;
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
