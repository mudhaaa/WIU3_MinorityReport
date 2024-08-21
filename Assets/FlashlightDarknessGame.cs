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
    int receiptamtfound = 0;
    int winebottleamtfound = 0;
    [SerializeField] int MaxAmtFound = 0;
    public BackgroundTransparencyAnim BlackBackground;
    public GameObject MainGame;

    public InventoryManager inventoryManager;
    public Item ReceiptReward;
    public Item WineBottleReward;
    public TimeSystem pTimeSystem;
    public DialogSystem pDialogSystem;

    public int ReceiptAmountFound {  
        get { return receiptamtfound; } 
        set {
            receiptamtfound = value; 
        }
    }
    public int WineBottleAmountFound 
    {
        get { return winebottleamtfound; }
        set
        {
            winebottleamtfound = value;
        }
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        InvetigationGUI.SetActive(true);
        receiptamtfound = 0;
        winebottleamtfound = 0;
        GlobalLight.enabled = false;

        pTimeSystem.pOnDayEnd += EndGame;
    }

    // Update is called once per frame
    void Update()
    {
        if (pDialogSystem.IsCompleted() == false)
        {
            return;
        }

        investigationtext.text = "Items Collected: " + (receiptamtfound + winebottleamtfound) + " / " + (MaxAmtFound);
        if (receiptamtfound + winebottleamtfound >= MaxAmtFound)
        {
            if (BlackBackground.CoroutineRunning == false)
            {
                BlackBackground.StartCoroutine(BlackBackground.AppearAnim(1.0f, 0.01f, 0.25f));
            }
            if (BlackBackground.canvasgroup.alpha >= 1.0f)
            {
                inventoryManager.AddItem(ReceiptReward, receiptamtfound);
                inventoryManager.AddItem(WineBottleReward, winebottleamtfound);
                MainGame.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

    public void EndGame()
    {
        MainGame.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GlobalLight.enabled = true;
        InvetigationGUI.SetActive(false);

        pTimeSystem.pOnDayEnd -= EndGame;
    }
}
