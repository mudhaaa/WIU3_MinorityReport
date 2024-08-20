using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTheBed : MonoBehaviour
{
    public bool FinishGame = false;
    public int PiecesPlaced;
    public GameObject MainGame;
    public GameObject MiniGame;
    public BackgroundTransparencyAnim BlackBackground;
    public LayerMask pickableLayers;
    // The layer that can be picked up


    // The object being dragged
    private GameObject draggedObject;




    // Start is called before the first frame update
    void Start()
    {
        pickableLayers = LayerMask.GetMask("Pillow") | LayerMask.GetMask("Blanket");
        PiecesPlaced = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, pickableLayers);

        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from the mouse position


            // Check if the ray hits something with the pickable layer
            if (hit.collider != null)
            {
                // Get the hit object
                GameObject hitObject = hit.collider.gameObject;

                // Check if the object has a Rigidbody2D component
                if (hitObject.GetComponent<Rigidbody2D>() != null)
                {
                    // Set the dragged object
                    draggedObject = hitObject;

                    // Make the object kinematic to prevent physics from interfering with the drag
                    hitObject.GetComponent<Rigidbody2D>().isKinematic = true;
                }
            }


        }


        // Check if the left mouse button is held down
        if (Input.GetMouseButton(0) && draggedObject != null)
        {
            // Get the mouse position in world space
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Move the dragged object to the mouse position
            draggedObject.transform.position = mousePosition;
        }

        // Check if the left mouse button is released
        if (Input.GetMouseButtonUp(0) && draggedObject != null)
        {
            // Make the object non-kinematic again
            draggedObject.GetComponent<Rigidbody2D>().isKinematic = false;

            // Reset the dragged object
            draggedObject = null;
        }

        if(PiecesPlaced >= 3)
        {
            FinishGame = true;
        }
        if (FinishGame)
        {
            if (BlackBackground.CoroutineRunning == false)
            {
                FinishGame = true;
                BlackBackground.StartCoroutine(BlackBackground.AppearAnim(1.0f, 0.01f, 0.25f));
            }
            if (BlackBackground.canvasgroup.alpha >= 1.0f)
            {
                FinishGame = false;
                MiniGame.SetActive(false);
                MainGame.SetActive(true);
            }
        }
    }
}
