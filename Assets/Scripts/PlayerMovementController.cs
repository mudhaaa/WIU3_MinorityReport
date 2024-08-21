using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private PlayerMainController playerMainController;
    public enum FacingDirection { Up, Down, Left, Right }

    public Vector2 DirectionFacing = Vector2.zero;

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
        if (!playerMainController.Hide)
        {
            Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


            if (Direction != Vector2.zero)
            {
                DirectionFacing = Direction;
            }
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = Direction * moveSpeed;
    }
}
