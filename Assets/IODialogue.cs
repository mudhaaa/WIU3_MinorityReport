using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IODialogue : MonoBehaviour, InteractableObject
{
    public DialogSystem dialogSystem;
    int count = 0;
    [SerializeField] private string[] filePath;
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

        dialogSystem.FilePath = filePath[count];
        dialogSystem.StartNewDialogues();
        if (filePath.Length - 1 > count)
        {
            count++;
        }
        //BlackBackground.StartCoroutine(BlackBackground.AppearAnim(1.0f, 0.01f, DelayTime));
    }
}
