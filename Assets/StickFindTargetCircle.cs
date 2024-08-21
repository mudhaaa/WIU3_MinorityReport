using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class StickFindTargetCircle : MonoBehaviour
{
    public string targetTag = "TargetCircle";  // Tag of the object that should disappear
    public float interactionTime = 2f;         // Time window to press "E" after collision
    private GameObject collidedObject;         // The object the player collides with
    private bool canPressKey = false;          // Flag to check if the player can press "E"
    private float timer = 0f;
    public int Hits = 0;
    public bool Hit = false;
    public AudioSource PickLockSound;
    [SerializeField] ParticleSystem ParticlePrefab;

    public DialogSystem pDialogSystem;

    // Start is called before the first frame update
    void OnEnable()
    {
        Hits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(pDialogSystem.IsCompleted() == false)
        {
            return;
        }

        Hit = false;
        if (canPressKey)
        {
            timer += Time.deltaTime;

            // Check if the "E" key is pressed within the interaction time
            if (Input.GetKeyDown(KeyCode.E) && timer <= interactionTime)
            {
                if(collidedObject != null)
                {
                    Hits++;
                    PickLockSound.Play();
                    Hit = true;
                    Instantiate(ParticlePrefab, collidedObject.transform.position, Quaternion.identity);
                    Destroy(collidedObject);
                }
                canPressKey = false;      // Reset the flag
            }

            // Reset if time exceeds interaction window
            if (timer > interactionTime)
            {
                canPressKey = false;
                timer = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the specific tag
        if (collision.gameObject.CompareTag(targetTag))
        {
            Debug.Log("Passing Through Ball");
            collidedObject = collision.gameObject;  // Store the collided object
            canPressKey = true;                     // Set flag to true
            timer = 0f;                             // Reset the timer
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Reset the flag when the collision ends
        if (collision.gameObject.CompareTag(targetTag))
        {
            canPressKey = false;
            timer = 0f;
        }
    }
}
