using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickForceApplier : MonoBehaviour
{
    public float forceMagnitude = 10f; // adjust this value to your liking
    public float radius = 1f; // adjust this value to your liking

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ApplyForceToNearbyRigidbodies(clickPosition);
            Debug.Log("click");
        }
    }

    void ApplyForceToNearbyRigidbodies(Vector2 clickPosition)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(clickPosition, radius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.isTrigger)
            {
                // Handle trigger collider
                Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 direction = (clickPosition - new Vector2(collider.transform.position.x, collider.transform.position.y)).normalized;
                    rb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);
                }
            }
            else
            {
                // Handle non-trigger collider
                Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 direction = (clickPosition - new Vector2(collider.transform.position.x, collider.transform.position.y)).normalized;
                    rb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);
                }
            }
        }
    }
}