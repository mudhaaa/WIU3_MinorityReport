using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    public float lifetime = 5f; // adjust the lifetime to your liking

    private void Start()
    {
        // Destroy the object after the lifetime
        Invoke("DestroyObject", lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the "abuser" tag
        if (collision.gameObject.tag == "Abuser")
        {


            DestroyObject();
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

}