using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlappyController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Vector3 JumpForce = new Vector3(0.0f, 100.0f, 0.0f);
    // Start is called before the first frame update

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.localPosition = Vector3.zero;
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Pressed For Flappy!");
            rb.velocity = JumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.enabled = false;
    }
}
