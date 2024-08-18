using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlappyDeathController : MonoBehaviour
{
    public BirdFlappyController birdFlappyController;
    public DeleteObjectsOnDisable InteractableObjects;
    float Timer;
    float MaxTimer = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        InteractableObjects.DeleteAllChildren();
    }
    // Update is called once per frame
    void Update()
    {
        if (birdFlappyController.enabled == false)
        {
            Timer += Time.deltaTime;
            if (Timer > MaxTimer)
            {
                Timer = 0.0f;
                birdFlappyController.enabled = true;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
    }
}
