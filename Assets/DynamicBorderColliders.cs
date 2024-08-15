using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DynamicBorderColliders : MonoBehaviour
{
    // Thickness of the border colliders
    public float thickness = 0.1f;
    public Transform Parent;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D[] colliders;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Initialize colliders array to hold 4 colliders
        colliders = new BoxCollider2D[4];

        // Add the initial colliders
        for (int i = 0; i < 4; i++)
        {
            colliders[i] = CreateCollider();
        }

        // Initial update to set the colliders' positions and sizes
        UpdateColliders();
    }

    void Update()
    {
        // Continuously update the colliders if the object changes
        UpdateColliders();
    }

    BoxCollider2D CreateCollider()
    {
        GameObject border = new GameObject("BorderCollider");
        border.transform.parent = Parent;
        border.transform.position = transform.position;
        return border.AddComponent<BoxCollider2D>();
    }

    void UpdateColliders()
    {
        Vector2 size = spriteRenderer.bounds.size;

        // Top collider
        colliders[0].size = new Vector2(size.x + thickness, thickness);
        colliders[0].offset = new Vector2(0, size.y / 2 + thickness / 2);

        // Bottom collider
        colliders[1].size = new Vector2(size.x + thickness, thickness);
        colliders[1].offset = new Vector2(0, -size.y / 2 - thickness / 2);

        // Left collider
        colliders[2].size = new Vector2(thickness, size.y + thickness);
        colliders[2].offset = new Vector2(-size.x / 2 - thickness / 2, 0);

        // Right collider
        colliders[3].size = new Vector2(thickness, size.y + thickness);
        colliders[3].offset = new Vector2(size.x / 2 + thickness / 2, 0);
    }
}
