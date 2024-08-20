using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GivePlayerItem : MonoBehaviour, InteractableObject
{
    [SerializeField] public DialogSystem dialogSystem;
    [SerializeField] public TimeSystem timeSystem;
    [SerializeField] public InventoryManager inventoryManager;
    [SerializeField] public Item item;
    [SerializeField] string NewInteractText = "Interact";
    [SerializeField] public bool ItemGiven;
    [SerializeField] public int Day;
    [SerializeField] public bool AnyDay;
    [SerializeField] public int ItemAmount;
    [SerializeField] public string dialogue = "";
    [SerializeField] public string dialogue1;
    [SerializeField] public string dialogue2;


    public GameObject InteractGUI;
    public TextMeshProUGUI InteractText;
    int count = 0;

    [SerializeField] Vector3 InteractGUIOffset = new Vector3(0, 1, 0);
    private void Start()
    {
        ItemGiven = false;
        dialogue = dialogue1;
    }


    public void Interact()
    {
        if (!ItemGiven && (Day == timeSystem.Day || AnyDay))
        {
            inventoryManager.AddItem(item, ItemAmount);
            ItemGiven = true;

            dialogSystem.FilePath = dialogue;
            dialogSystem.StartNewDialogues();
            dialogue = dialogue2;
        }
        else
        {

            dialogSystem.FilePath = dialogue;
            dialogSystem.StartNewDialogues();
        }

    }

    public void ShowInteractGUI()
    {
        InteractText.text = NewInteractText;
        InteractGUI.SetActive(true);
        InteractGUI.transform.position = transform.position + InteractGUIOffset;
    }
}
