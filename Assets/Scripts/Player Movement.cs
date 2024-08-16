using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private MovementController moveController;

    [SerializeField]
    private CharacterRenderer CharRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        CharRenderer.SetDirection(horizontal, vertical);

        // Pass X and Y inputs to the MovementController
        moveController.MovePosition(new Vector2(horizontal, vertical));
    }

    private void Update()
    {
        HandleUpdate();
    }
}
