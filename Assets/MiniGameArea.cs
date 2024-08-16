using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameArea : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector2 ObjectScaleOnScreen;
    void Awake()
    {
        // Apply the scale
        transform.localScale = GetScale();
    }

    // Update is called once per frame
    void Update()
    {
        // Apply the scale
        transform.localScale = GetScale();
    }

    public Vector3 GetScale()
    {
        Camera mainCamera = Camera.main;

        // Calculate screen width and height in world units
        float screenHeight = 2f * mainCamera.orthographicSize;
        float screenWidth = screenHeight * mainCamera.aspect;

        // Get the sprite's size
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        // Calculate the scale factor needed
        Vector3 scale = transform.localScale;
        scale.x = (screenWidth / spriteSize.x) * ObjectScaleOnScreen.x;
        scale.y = (screenHeight / spriteSize.y) * ObjectScaleOnScreen.y;
        return scale;
    }
}
