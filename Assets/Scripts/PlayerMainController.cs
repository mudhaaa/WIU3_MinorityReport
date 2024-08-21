using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainController : MonoBehaviour
{
    [SerializeField] AnimationEvents animationEvent;
    // Start is called before the first frame update
    [SerializeField] public bool Hide;
    [SerializeField] public bool Died;
    AnimationController AnimationController;
    Rigidbody2D rb;

    [SerializeField] TimeSystem pTimeSystem;
    [SerializeField] Transform[] SpawnPoints;
    [SerializeField] Vector3 originalPosition;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] InteractController interactController;
    void Start()
    {
        AnimationController = GetComponent<AnimationController>();
        rb = GetComponent<Rigidbody2D>();
        Hide = false;
        Died = false;

        pTimeSystem.pOnDayStart += OnDayStart;
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
        if (Input.GetKeyUp(KeyCode.E) && Hide)
        {
            Unhide();
            Debug.Log("unhide");
        }

    }

    public void CheckThisFrame()
    {
        Debug.Log("ThisFrame");
    }

    public void OnDayStart()
    {
        if (pTimeSystem.Day <= 3)
        {
            transform.position = SpawnPoints[0].position;
        }
        else if (pTimeSystem.Day > 3)
        {
            transform.position = SpawnPoints[1].position;
        }
    }

    public void Hiding()
    {
        Hide = true;
        originalPosition = transform.position;
        sprite.enabled = false;
        interactController.enabled = false;
        GetComponent<Renderer>().enabled = false; // disable renderer to make player invisible
        GetComponent<Collider2D>().enabled = false; // disable collider to make player non-collidable
    }

    public void Unhide()
    {
        Hide = false;
        sprite.enabled = true;
        interactController.enabled = true;
        GetComponent<Renderer>().enabled = true; // enable renderer to make player visible again
        GetComponent<Collider2D>().enabled = true; // enable collider to make player collidable again
        transform.position = originalPosition; // restore original position
    }
}