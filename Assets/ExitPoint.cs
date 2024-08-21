using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ExitPoint : MonoBehaviour, InteractableObject
{
    public GameObject InteractGUI;
    public TextMeshProUGUI InteractText;
    [SerializeField] string NewInteractText = "Exit";

    [SerializeField] Vector3 InteractGUIOffset = new Vector3(0, 1, 0);

    public StateController AbuserState;

    public InventoryManager inventory;
    public DialogSystem dialogSystem;
    public TimeSystem pTimeSystem;
    public SceneFunctions sceneFunctions;


    public void Interact()
    {
        if(pTimeSystem.Day < 4)
        {
            dialogSystem.FilePath = "Assets/Dialog/ExitPointDialogueLocked.txt";
            dialogSystem.StartNewDialogues();
        }
        else
        {
            dialogSystem.onDialogEnd += PlayEnding;
            dialogSystem.FilePath = "Assets/Dialog/ExitPointDialogue.txt";
            dialogSystem.StartNewDialogues();
        }
    }

    public void ShowInteractGUI()
    {
        InteractText.text = NewInteractText;
        InteractGUI.SetActive(true);
        InteractGUI.transform.position = transform.position + InteractGUIOffset;
    }

    public void PlayEnding()
    {
        dialogSystem.onDialogEnd -= PlayEnding;

        if(GameManager.isMale == true && AbuserState.gotHit == true)
        {
            dialogSystem.onDialogEnd += sceneFunctions.LoadMaleBE;
            GameManager.Instance.IsEndingCompleted[1] = true;
            dialogSystem.FilePath = "Assets/Dialog/MaleBadEnding.txt";
        }
        else if (inventory.ReturnTotalEvidenceAmt() < 14)
        {
            dialogSystem.onDialogEnd += sceneFunctions.LoadSuicide;
            GameManager.Instance.IsEndingCompleted[4] = true;
            dialogSystem.FilePath = "Assets/Dialog/SuicideEnding.txt";
        }
        else if(inventory.ReturnTotalEvidenceAmt() >= 14)
        {
            if (GameManager.isMale == true)
            {
                dialogSystem.onDialogEnd += sceneFunctions.LoadMaleGE;
                GameManager.Instance.IsEndingCompleted[2] = true;
                dialogSystem.FilePath = "Assets/Dialog/MaleGoodEnding.txt";
            }
            else
            {
                dialogSystem.onDialogEnd += sceneFunctions.LoadFemaleGE;
                GameManager.Instance.IsEndingCompleted[3] = true;
                dialogSystem.FilePath = "Assets/Dialog/FemaleGoodEnding.txt";
            }
        }

        dialogSystem.StartNewDialogues();
    }
}
