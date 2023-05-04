using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
     private bool isDragging = false;
    private Vector3 lastMousePosition;
    private Vector3 center;

    public float rotationSpeed = 5.0f;

    private bool isRotatingHorizontally = false;
    private bool isRotatingVertically = false;

    void Start()
    {
        // Calculate center of the object
        center = GetComponent<Renderer>().bounds.center;
    }

    void OnMouseDrag()
    {
        isDragging = true;
        Vector3 currentMousePosition = Input.mousePosition;

        if (lastMousePosition != Vector3.zero)
        {
            float rotationX = (currentMousePosition.y - lastMousePosition.y) * rotationSpeed;
            float rotationY = (currentMousePosition.x - lastMousePosition.x) * rotationSpeed;

            // Check if we're rotating horizontally or vertically
            if (!isRotatingHorizontally && Mathf.Abs(rotationY) > Mathf.Abs(rotationX))
            {
                isRotatingVertically = true;
                isRotatingHorizontally = false;
            }
            else if (!isRotatingVertically && Mathf.Abs(rotationX) > Mathf.Abs(rotationY))
            {
                isRotatingHorizontally = true;
                isRotatingVertically = false;
            }

            // Rotate horizontally or vertically
            if (isRotatingHorizontally)
            {
                transform.RotateAround(center, Vector3.up, rotationY);
            }
            else if (isRotatingVertically)
            {
                transform.RotateAround(center, Vector3.right, -rotationX);
            }
        }

        lastMousePosition = currentMousePosition;
    }

    void OnMouseUp()
    {
        isDragging = false;
        lastMousePosition = Vector3.zero;
        isRotatingHorizontally = false;
        isRotatingVertically = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(center, Vector3.up, -rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(center, Vector3.up, rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.RotateAround(center, Vector3.right, -rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.RotateAround(center, Vector3.right, rotationSpeed);
        }
    }
}
