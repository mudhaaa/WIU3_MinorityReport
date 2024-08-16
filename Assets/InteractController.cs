using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    public BackgroundTransparencyAnim BlackBackground;
    public GameObject MiniGameBackground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && BlackBackground.CoroutineRunning == false && MiniGameBackground.activeSelf == false)
        {
            Collider2D NearestCollision = null;
            float NearestDistance = 0;
            Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, 2.0f);
            InteractableObject Nearestinteractable = null;
            for (int i = 0; i < collisions.Length; i++)
            {
                //Debug.Log("Object " + i);
                Collider2D collision = collisions[i];
                InteractableObject interactable = null;
                interactable = collision.gameObject.GetComponent<InteractableObject>();
                if (collision != null && interactable != null)
                {
                    Nearestinteractable = interactable;
                    Debug.Log("Interactable Object " + collision.gameObject.name);
                    float Distance = Vector2.Distance(collision.gameObject.transform.position, transform.position);
                    if(NearestCollision == null || Distance < NearestDistance)
                    {
                        NearestCollision = collision;
                        NearestDistance = Distance;
                    }
                }
            }
            if (NearestCollision != null) {
                Nearestinteractable.Interact();
            }
        }
    }
}
