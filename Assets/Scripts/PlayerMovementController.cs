using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject projectilePrefab; // Assign your projectile prefab in the Inspector
    [SerializeField] private GameObject gluePrefab;
    public enum FacingDirection { Up, Down, Left, Right }

    public FacingDirection facingDirection;

    // Start is called before the first frame update
    Vector2 Direction = Vector2.zero;
    Rigidbody2D rb;

    void Start()
    {
        moveSpeed = 5f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Direction = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);

        if (Input.GetKeyDown(KeyCode.E))
        {
            ShootProjectile();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnGlue();
        }
        // Update facing direction based on input
        if (Input.GetKeyDown(KeyCode.W))
        {
            facingDirection = FacingDirection.Up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            facingDirection = FacingDirection.Down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            facingDirection = FacingDirection.Left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            facingDirection = FacingDirection.Right;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = Direction;
    }

    private void ShootProjectile()
    {
        Vector2 projectileDirection;

        switch (facingDirection)
        {
            case FacingDirection.Up:
                projectileDirection = Vector2.up;
                break;
            case FacingDirection.Down:
                projectileDirection = Vector2.down;
                break;
            case FacingDirection.Left:
                projectileDirection = Vector2.left;
                break;
            case FacingDirection.Right:
                projectileDirection = Vector2.right;
                break;
            default:
                projectileDirection = Vector2.zero;
                break;
        }

        // Calculate the spawn position of the projectile
        Vector3 spawnPosition = transform.position + new Vector3(projectileDirection.x, projectileDirection.y, 0);
        // Instantiate the projectile prefab
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        // Set the projectile's velocity based on the direction
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = projectileDirection * 10f; // Adjust the speed to your liking
    }

    private void SpawnGlue()
    {
        // Instantiate the special object prefab at the player's current position
        GameObject specialObject = Instantiate(gluePrefab, transform.position, Quaternion.identity);
    }
}
