using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashlightDarknessGame : MonoBehaviour
{
    public Light2D GlobalLight;
    float prev_intensity = 0.5f;
    int amtfound = 0;
    [SerializeField] int MaxAmtFound = 0;
    public BackgroundTransparencyAnim BlackBackground;
    public GameObject MainGame;

    public int AmountFound {  
        get { return amtfound; } 
        set {
            amtfound = value; 
        }
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        amtfound = 0;
        prev_intensity = GlobalLight.intensity;
        GlobalLight.intensity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (amtfound >= MaxAmtFound)
        {
            if (BlackBackground.CoroutineRunning == false)
            {
                BlackBackground.StartCoroutine(BlackBackground.AppearAnim(1.0f, 0.01f, 0.25f));
            }
            if (BlackBackground.canvasgroup.alpha >= 1.0f)
            {
                MainGame.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        GlobalLight.intensity = prev_intensity;
    }
}
