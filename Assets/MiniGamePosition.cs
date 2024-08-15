using UnityEngine;

public class MiniGamePosition : MonoBehaviour
{
    public Vector2 screenPosition; // Values between 0 and 1, e.g., (0.5f, 0.5f) is the center

    void Start()
    {
    }
    private void Update()
    {
        // Get the main camera
        Camera mainCamera = Camera.main;

        // Convert screen position to world position
        Vector3 worldPosition = mainCamera.ViewportToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, mainCamera.nearClipPlane));

        // Set the object's position
        transform.position = worldPosition;
    }
}