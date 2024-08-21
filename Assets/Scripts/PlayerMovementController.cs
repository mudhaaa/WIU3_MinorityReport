using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

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
        Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        if (Direction != Vector2.zero)
        {
            DirectionFacing = Direction;
        }
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    SpawnGlue();
        //}
    }
    private void FixedUpdate()
    {
        rb.velocity = Direction * moveSpeed;
    }
}
