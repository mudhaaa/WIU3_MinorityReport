using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staircase : MonoBehaviour
{
    // The position to transport the player to
    [SerializeField] private Transform otherStaircase;

    //
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with the stairs
        if (collision.gameObject.CompareTag("Player"))
        {
            // Transport the player to the new position
            collision.gameObject.transform.position = otherStaircase.position;
        }
    }
}
