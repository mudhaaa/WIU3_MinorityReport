using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlappyObstacle : MonoBehaviour
{
    [SerializeField] float HorSpeed = -1.0f;

    public DialogSystem pDialogSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(pDialogSystem.IsCompleted() == false)
        {
            return;
        }

        transform.position = new Vector3(transform.position.x + HorSpeed, transform.position.y, transform.position.z);
    }
}
