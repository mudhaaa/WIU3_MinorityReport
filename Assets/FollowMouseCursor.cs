using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseCursor : MonoBehaviour
{
    Vector2 mousePosition;
    Vector2 initialMousePosition;

    public DialogSystem pDialogSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pDialogSystem.IsCompleted() == false)
        {
            return;
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Direction = mousePosition - initialMousePosition;
        transform.position = mousePosition;
    }
}
