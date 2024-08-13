using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    public DialogSystem pDialogSystem;

    public const float LengthOfTime = 480;
    public static float TimeMultipler = 1.0f;

    public float currentTiming;

    public bool warningGiven;


    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.deltaTime * TimeMultipler);
        currentTiming += Time.deltaTime * TimeMultipler;

        if(currentTiming >= 420.0f && warningGiven == false)
        {
            GiveWarning();
        }


    }

    private void GiveWarning()
    {
        pDialogSystem.FilePath = "Assets/Dialog/5pmWarning.txt";
        pDialogSystem.StartNewDialogues();

        warningGiven = true; 
    }

    private void OnDayEnd()
    {
        Debug.Log("Is night time now.");
    }
}
