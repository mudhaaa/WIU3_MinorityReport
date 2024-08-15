using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject2D : MonoBehaviour
{
    [Header("Physics 2D")]
    public Rigidbody2D rb;

    private Vector2 mousePosition = Vector2.zero;
    private Vector2 initialPosition;
    private Vector2 initialMousePosition;
    private bool isDragging = false;

    void Update()
    {
        if (isDragging)
        {
            initialMousePosition = mousePosition;

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 Direction = mousePosition - initialMousePosition;
            rb.MovePosition(mousePosition);
            
            rb.velocity = Direction * 100.0f;
        }
    }

    void OnMouseDown()
    {
        Debug.Log("YEAHYEAH");
        isDragging = true;
        initialPosition = transform.position;
    }

    void OnMouseUp()
    {
        isDragging = false;
        // Optional: snap back to initial position
        // rb.MovePosition(initialPosition);
    }

    void OnMouseDrag()
    {
        // Do nothing, handled in Update()
    }
}