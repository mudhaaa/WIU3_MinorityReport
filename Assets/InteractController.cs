using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    public GameObject InteractGUI;
    public BackgroundTransparencyAnim BlackBackground;
    public GameObject MiniGameBackground;

    public GameObject[] FirstDayObjects;
    public GameObject[] SecondDayObjects;
    public GameObject[] ThirdDayObjects;
    public GameObject[] FourthDayObjects;
    public GameObject[] FifthDayObjects;
    public TimeSystem timeSystem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
            if (collision != null && interactable != null &&
                (
                    (timeSystem.Day == 0 && FirstDayObjects.Contains(collision.gameObject)) ||
                    (timeSystem.Day == 1 && SecondDayObjects.Contains(collision.gameObject)) ||
                    (timeSystem.Day == 2 && ThirdDayObjects.Contains(collision.gameObject)) ||
                    (timeSystem.Day == 3 && FourthDayObjects.Contains(collision.gameObject)) ||
                    (timeSystem.Day == 4 && FifthDayObjects.Contains(collision.gameObject))
                )
                )
            {
                Debug.Log("Interactable Object " + collision.gameObject.name);
                float Distance = Vector2.Distance(collision.gameObject.transform.position, transform.position);
                if (NearestCollision == null || Distance < NearestDistance)
                {
                    Nearestinteractable = interactable;
                    NearestCollision = collision;
                    NearestDistance = Distance;
                }
            }
        }
        if (Nearestinteractable != null)
        {
            Nearestinteractable.ShowInteractGUI();
        }
        else
        {
            InteractGUI.SetActive(false);
        }
        // put else then set the gui active to false
        if (Input.GetKeyUp(KeyCode.E) && BlackBackground.CoroutineRunning == false && MiniGameBackground.activeSelf == false)
        {
            if (NearestCollision != null) {
                Nearestinteractable.Interact();
            }
        }
    }
}
