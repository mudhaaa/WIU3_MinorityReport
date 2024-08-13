using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    // Start is called before the first frame update

    public void MovePosition(Vector2 direction)
    {
        transform.position += new Vector3(direction.x, direction.y / 2) * moveSpeed * Time.deltaTime;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
