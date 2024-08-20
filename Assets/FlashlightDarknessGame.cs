using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashlightDarknessGame : MonoBehaviour
{
    public Light2D GlobalLight;
    public GameObject InvetigationGUI;
    public TextMeshProUGUI investigationtext;
    float prev_intensity = 0.5f;
    int amtfound = 0;
    [SerializeField] int MaxAmtFound = 0;
    public BackgroundTransparencyAnim BlackBackground;
    public GameObject MainGame;

    public InventoryManager inventoryManager;
    public Item EvidenceReward;

    public int AmountFound {  
        get { return amtfound; } 
        set {
            amtfound = value; 
        }
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        InvetigationGUI.SetActive(true);
        amtfound = 0;
        GlobalLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        investigationtext.text = "Items Collected: " + (amtfound) + " / " + (MaxAmtFound);
        if (amtfound >= MaxAmtFound)
        {
            if (BlackBackground.CoroutineRunning == false)
            {
                BlackBackground.StartCoroutine(BlackBackground.AppearAnim(1.0f, 0.01f, 0.25f));
            }
            if (BlackBackground.canvasgroup.alpha >= 1.0f)
            {
                inventoryManager.AddItem(EvidenceReward, amtfound);
                MainGame.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        GlobalLight.enabled = true;
        InvetigationGUI.SetActive(false);
    }
}
