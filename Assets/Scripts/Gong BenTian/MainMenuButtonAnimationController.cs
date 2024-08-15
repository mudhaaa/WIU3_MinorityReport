using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonAnimationController : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("Normal"))
        {
            animator.Play("Null");
        }
        else if(animator.GetBool("Highlighted"))
        {
            animator.Play("Highlighted");
        }
    }
}
