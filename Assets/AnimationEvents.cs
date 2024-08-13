using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] public GameObject[] FootSteps;
    GameObject currentfootstep; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FootstepSound()
    {
        currentfootstep = FootSteps[Random.Range(0, FootSteps.Length)];
        currentfootstep.SetActive(true);
    }
    void Stand()
    {
        if (currentfootstep != null) {
            currentfootstep.SetActive(false);
        }
    }
}
