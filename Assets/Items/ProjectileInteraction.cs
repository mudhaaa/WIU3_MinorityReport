using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(menuName = "Scriptable object/Projectile Interaction")]
public class ProjectileInteraction : ItemInteraction
{
    [SerializeField] private GameObject ProjectilePrefab;
    Item ItemParentedTo;
    public override bool Interact(GameObject Parent)
    {
        // Calculate the spawn position of the projectile
        Vector2 Direction = Parent.GetComponent<PlayerMovementController>().DirectionFacing;
        Vector3 spawnPosition = Parent.transform.position + new Vector3(Direction.x, Direction.y, 0);
        // Instantiate the projectile prefab
        GameObject projectile = Instantiate(ProjectilePrefab, spawnPosition, Quaternion.identity);

        // Set the projectile's velocity based on the direction
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = Direction * 10f; // Adjust the speed to your liking
        return true;
    }

    public override void Init(Item Parent)
    {
        ItemParentedTo = Parent;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
