using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

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
    }
    private void FixedUpdate()
    {
        rb.velocity = Direction;
    }
}
