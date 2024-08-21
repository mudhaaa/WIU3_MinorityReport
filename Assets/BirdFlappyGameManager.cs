using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BirdFlappyGameManager : MonoBehaviour
{
    public GameObject ScoreUI;
    public TextMeshProUGUI ScoreText;
    public GameObject BirdFlappy;
    public BirdFlappyController BirdFlappyController;
    public SnakeController SnakeController;
    public GameObject FlappyEndUI;
    [SerializeField] AudioSource AddedSFX;
    int count = 0;

    public int FlappyCount {  
        get { 
            return count; 
        }
        set
        {
            if ((BirdFlappyController != null && BirdFlappyController.enabled) || (SnakeController != null && SnakeController.enabled))
            {
                if(value > count)
                {
                    AddedSFX.Play();
                }
                count = value;
                ScoreText.text = count.ToString();
            }
        }
        
    }

    private void OnEnable()
    {
        BirdFlappy.SetActive(true);
        ScoreUI.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (BirdFlappy.activeSelf == false)
        {
            FlappyEndUI.SetActive(true);
        }
    }

    private void OnDisable()
    {
        ScoreUI.SetActive(false);
    }
}
