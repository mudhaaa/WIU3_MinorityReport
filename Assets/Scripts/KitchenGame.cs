using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGame : MonoBehaviour
{
    // The layer that can be picked up
    public LayerMask pickableLayer;

    // The object being dragged
    private GameObject draggedObject;

    public GameObject[] objectsToDeactivate;

    // Start is called before the first frame update
    void Start()
    {
        // Deactivate the objects
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits something with the pickable layer
            if (Physics.Raycast(ray, out hit, 100f, pickableLayer))
            {
                // Get the hit object
                GameObject hitObject = hit.transform.gameObject;

                // Check if the object has a Rigidbody component
                if (hitObject.GetComponent<Rigidbody>() != null)
                {
                    // Set the dragged object
                    draggedObject = hitObject;

                    // Make the object kinematic to prevent physics from interfering with the drag
                    hitObject.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }

        // Check if the left mouse button is held down
        if (Input.GetMouseButton(0) && draggedObject != null)
        {
            // Get the mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Move the dragged object to the mouse position
            draggedObject.transform.position = mousePosition;
        }

        // Check if the left mouse button is released
        if (Input.GetMouseButtonUp(0) && draggedObject != null)
        {
            // Make the object non-kinematic again
            draggedObject.GetComponent<Rigidbody>().isKinematic = false;

            // Reset the dragged object
            draggedObject = null;
        }
    }
}