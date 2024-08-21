using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlappyController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Vector3 JumpForce = new Vector3(0.0f, 100.0f, 0.0f);
    [SerializeField] Animator animator;
    [SerializeField] AudioSource FlappyHit;
    [SerializeField] AudioSource FlappyJump;

    float turnSpeed = 10; // Turret movement parameter

    public DialogSystem pDialogSystem;

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
        if(pDialogSystem.IsCompleted() == false)
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Pressed For Flappy!");
            animator.Play("Jump");
            rb.velocity = JumpForce;
            FlappyJump.Play();
        }
        // Check if there is any velocity
        if (rb.velocity != Vector2.zero)
        {

            if (rb.velocity.y < 0.0f)
            {
                animator.Play("Idle");
            }
            // Calculate the angle in degrees
            float angle = Mathf.Atan2(rb.velocity.y, 2.0f) * Mathf.Rad2Deg;

            // Create a rotation based on the angle
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }

    public void FixedUpdate()
    {
        if (pDialogSystem.IsCompleted() == false)
        {
            rb.velocity = Vector3.zero;
            rb.gravityScale = 0;
        }
        else if (rb.gravityScale < 1 && pDialogSystem.IsCompleted() == true)
        {
            rb.gravityScale = 2;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.enabled)
        {
            FlappyHit.Play();
            this.enabled = false;
        }
    }
}
