using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITester : MonoBehaviour
{
    public DialogSystem dialogSystem;
    // Start is called before the first frame update
    void Start()
    {
        dialogSystem.FilePath = "Assets/Dialog/test.txt";
        dialogSystem.StartNewDialogues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
