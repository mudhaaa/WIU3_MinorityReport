using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRectangleToScreen : MonoBehaviour
{
    // Reference to the camera
    public Camera mainCamera;

    // Multiplier to control the scaling relative to screen size (1 means full screen)
    public float scaleFactorX = 1.0f;
    public float scaleFactorY = 1.0f;

    void Update()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        // Calculate screen height and width in world units
        float screenHeight = 2f * mainCamera.orthographicSize;
        float screenWidth = screenHeight * mainCamera.aspect;

        // Determine the smaller dimension to maintain a square shape
        float smallerScreenDimension = Mathf.Min(screenWidth, screenHeight);

        // Get the size of the sprite
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        // Scale the object uniformly based on the smaller screen dimension
        float scaleX = (smallerScreenDimension / spriteSize.x) * scaleFactorX;
        float scaleY = (screenHeight / spriteSize.y) * scaleFactorY;

        transform.localScale = new Vector3(scaleX, scaleY, 1);  // Maintain square shape
    }
}
