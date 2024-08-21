using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HideInCloset : MonoBehaviour, InteractableObject
{
    [SerializeField] public DialogSystem dialogSystem;
    [SerializeField] public TimeSystem timeSystem;
    [SerializeField] string NewInteractText = "Hide";
    [SerializeField] PlayerMainController playerMainController;


    public GameObject InteractGUI;
    public TextMeshProUGUI InteractText;
    int count = 0;
    [SerializeField] Vector3 InteractGUIOffset = new Vector3(0, 1, 0);
    public void Interact()
    {

        if (!playerMainController.Hide)
        {
            playerMainController.Hiding();
        }





    }

    public void ShowInteractGUI()
    {
        InteractText.text = NewInteractText;
        InteractGUI.SetActive(true);
        InteractGUI.transform.position = transform.position + InteractGUIOffset;
    }
}
