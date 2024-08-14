using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playertest : MonoBehaviour
{
    [SerializeField] public Player testPlayer;
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an enemy
        if (collision.gameObject.CompareTag("Abuser"))
        {
            // Destroy the player GameObject
            testPlayer.Died = true;
        }
    }
}
