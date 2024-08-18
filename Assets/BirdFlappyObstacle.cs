using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlappyObstacle : MonoBehaviour
{
    [SerializeField] float HorSpeed = -1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + HorSpeed, transform.position.y, transform.position.z);
    }
}
