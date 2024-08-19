using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glue : MonoBehaviour
{
    public float slowDownFactor = 0.5f; // adjust the slow down factor to your liking

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the "Abuser" tag
        if (collision.gameObject.tag == "Abuser")
        {
            // Get the StateController component of the collided object
            StateController controller = collision.gameObject.GetComponent<StateController>();

            // If the controller is found, slow down its move speed
            if (controller != null)
            {
                controller.moveSpeed *= slowDownFactor;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the collided object has the "Abuser" tag
        if (collision.gameObject.tag == "Abuser")
        {
            // Get the StateController component of the collided object
            StateController controller = collision.gameObject.GetComponent<StateController>();

            // If the controller is found, reset its move speed
            if (controller != null)
            {
                controller.moveSpeed /= slowDownFactor;
            }
        }
    }
}
