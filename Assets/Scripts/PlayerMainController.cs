using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainController : MonoBehaviour
{
    // Start is called before the first frame update
    AnimationController AnimationController;
    Rigidbody2D rb;
    void Start()
    {
        AnimationController = GetComponent<AnimationController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 0)
        {
            AnimationController.PlayAnimation(rb.velocity, "Walk");
        }
        else
        {
            AnimationController.PlayAnimation(rb.velocity, "Idle");
        }
    }
}
