using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlappyCount : MonoBehaviour
{
    public BirdFlappyGameManager BirdFlappyGameManager;
    // Start is called before the first frame update
    void Start()
    {
        BirdFlappyGameManager = GameObject.FindObjectOfType<BirdFlappyGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BirdFlappyGameManager.FlappyCount++;
    }
}
