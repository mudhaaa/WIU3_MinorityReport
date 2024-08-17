using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaundryBasket : MonoBehaviour
{
    [SerializeField] public LayerMask layer;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has a certain layer
        if ((layer.value & (1 << other.gameObject.layer)) > 0)
        {
            // Make the collided object inactive
            other.gameObject.SetActive(false);
        }
    }
}