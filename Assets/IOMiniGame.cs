using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IOMiniGame : MonoBehaviour, InteractableObject
{
    public GameObject InteractGUI;
    public TextMeshProUGUI InteractText;
    [SerializeField] string NewInteractText = "Interact";

    public BackgroundTransparencyAnim BlackBackground;
    [SerializeField] Vector3 InteractGUIOffset = new Vector3(0, 1,0);
    public DialogSystem dialogSystem;
    public GameObject MainGame;
    public GameObject MiniGame;
    bool Activated = false;
    [SerializeField] float DelayTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Activated)
        {
            if (BlackBackground.canvasgroup.alpha >= 1.0f)
            {
                Activated = false;
                MiniGame.SetActive(true);
                MainGame.SetActive(false);
            }
        }
    }

    public void Interact()
    {
        dialogSystem.FilePath = "Assets/Dialog/ToiletDialogue.txt";
        dialogSystem.StartNewDialogues();
        Activated = true;
        BlackBackground.StartCoroutine(BlackBackground.AppearAnim(1.0f, 0.01f, DelayTime));
    }
    public void ShowInteractGUI()
    {
        InteractText.text = NewInteractText;
        InteractGUI.SetActive(true);
        InteractGUI.transform.position = transform.position + InteractGUIOffset;
    }
}
