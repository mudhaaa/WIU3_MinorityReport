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

    public int Day;
    public bool IsNight;
    public bool NextDay;


    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.deltaTime * TimeMultipler);
        currentTiming += Time.deltaTime * TimeMultipler;

        if(currentTiming >= (420.0f) && warningGiven == false)
        {
            GiveWarning();
            return;
        }
        else if(currentTiming >= LengthOfTime && IsNight == false)
        {
            EndTheDay();
        }
        else if(IsNight == true && NextDay == true)
        {
            StartNextDay();
        }
        
    }

    private void GiveWarning()
    {
        pDialogSystem.FilePath = "Assets/Dialog/5pmWarning.txt";
        pDialogSystem.StartNewDialogues();

        warningGiven = true; 
    }

    private void EndTheDay()
    {
        pDialogSystem.FilePath = "Assets/Dialog/femalenight" + Day + ".txt";
        pDialogSystem.StartNewDialogues();

        IsNight = true;
    }

    private void StartNextDay()
    {
        ++Day;
        currentTiming = 0;

        warningGiven = false;
        IsNight = false;
        NextDay = false;
    }
}
