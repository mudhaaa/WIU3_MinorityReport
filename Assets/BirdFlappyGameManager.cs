using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlappyGameManager : MonoBehaviour
{
    public GameObject BirdFlappy;
    public GameObject FlappyEndUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        BirdFlappy.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (BirdFlappy.activeSelf == false)
        {
            FlappyEndUI.SetActive(true);
        }
    }
}
