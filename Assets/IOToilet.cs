using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOToilet : MonoBehaviour, InteractableObject
{
    public DialogSystem dialogSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        //Debug.Log("Niggers");
        dialogSystem.FilePath = "Assets/Dialog/ToiletDialogue.txt";
        dialogSystem.StartNewDialogues();
    }
}
