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
    public bool isDragging = false;
    [SerializeField] AudioSource SoundOnDrag;
    [SerializeField] AudioSource SoundOnCollision;

    public DialogSystem pDialogSystem;

    void Update()
    {
        if(pDialogSystem.IsCompleted() == false)
        {
            return;
        }

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
        if (SoundOnDrag != null)
        {
            SoundOnDrag.Play();
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (SoundOnCollision != null)
            SoundOnCollision.Play();
    }
}