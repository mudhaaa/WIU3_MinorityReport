using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TimeSystem : MonoBehaviour
{
    public DialogSystem pDialogSystem;
    public InventoryManager pInventoryManager;

    public SceneFunctions sceneFunctions;

    public Animator globalLightAnimator;

    public const int TotalOfDay = 5;
    public int Day;

    public const float LengthOfTime = 480;
    public const float NormalTimeMultipler = 60.0f;
    public const float DialogTimeMultipler = 0.0f;
    public static float TimeMultipler = 1.0f;

    public float currentTiming;

    public bool warningGiven;

    public bool IsNight;
    public bool NextDay;


    private void Start()
    {
        StartNextDay();
    }

    // Update is called once per frame
    void Update()
    {
        currentTiming += Time.deltaTime * TimeMultipler;
        globalLightAnimator.speed = TimeMultipler;
        
        if (currentTiming < 120.0f)
        {
            globalLightAnimator.Play("Morning");
        }
        else if (currentTiming >= 120.0f && currentTiming < 360.0f)
        {
            globalLightAnimator.Play("Afternoon");
        }
        else if (currentTiming >= 360.0f)
        {
            globalLightAnimator.Play("Evening");
        }
        else if(currentTiming >= 420.0f)
        {
            globalLightAnimator.Play("Night");
        }


        if (currentTiming >= (420.0f) && warningGiven == false && Day < 4)
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
        IsNight = true;

        ++Day;
        if (Day >= 5)
        {
            if (pInventoryManager.evidenceSlot.transform.childCount > 0)
            {
                if (pInventoryManager.evidenceSlot.transform.GetChild(0).GetComponent<InventoryItem>().count < 4)
                {
                    pDialogSystem.onDialogEnd += sceneFunctions.LoadSuicide;
                    pDialogSystem.FilePath = "Assets/Dialog/Ending 5.txt";
                    GameManager.Instance.IsEndingCompleted[4] = true;
                }
                else if (pInventoryManager.evidenceSlot.transform.GetChild(0).GetComponent<InventoryItem>().count >= 4)
                {
                    if (GameManager.isMale == true)
                    {
                        pDialogSystem.onDialogEnd += sceneFunctions.LoadMaleGE;
                        pDialogSystem.FilePath = "Assets/Dialog/Ending 3.txt";
                        GameManager.Instance.IsEndingCompleted[2] = true;
                    }
                    else
                    {
                        pDialogSystem.onDialogEnd += sceneFunctions.LoadFemaleGE;
                        pDialogSystem.FilePath = "Assets/Dialog/Ending 4.txt";
                        GameManager.Instance.IsEndingCompleted[3] = true;
                    }
                }
            }
            else
            {
                pDialogSystem.onDialogEnd += sceneFunctions.LoadSuicide;
                pDialogSystem.FilePath = "Assets/Dialog/Ending 5.txt";
                GameManager.Instance.IsEndingCompleted[4] = true;
            }
        }
        else
        {
            switch (Day)
            {
                case 1:
                    {
                        if (GameManager.isMale == true)
                        {
                            pDialogSystem.FilePath = "Assets/Dialog/MaleNight1.txt";
                        }
                        else if (GameManager.isMale == false)
                        {
                            pDialogSystem.FilePath = "Assets/Dialog/FemaleNight1.txt";
                        }

                        break;
                    }
                case 2:
                    {
                        if (GameManager.isMale == true)
                        {
                            pDialogSystem.FilePath = "Assets/Dialog/MaleNight2.txt";
                        }
                        else if (GameManager.isMale == false)
                        {
                            pDialogSystem.FilePath = "Assets/Dialog/FemaleNight2.txt";
                        }

                        break;
                    }
                case 3:
                    {
                        if (GameManager.isMale == true)
                        {
                            pDialogSystem.FilePath = "Assets/Dialog/MaleNight3.txt";
                        }
                        else if (GameManager.isMale == false)
                        {
                            pDialogSystem.FilePath = "Assets/Dialog/FemaleNight3.txt";
                        }

                        break;
                    }
                case 4:
                    {
                        if (GameManager.isMale == true)
                        {
                            pDialogSystem.FilePath = "Assets/Dialog/MaleNight4.txt";
                        }
                        else if (GameManager.isMale == false)
                        {
                            pDialogSystem.FilePath = "Assets/Dialog/FemaleNight4.txt";
                        }

                        break;
                    }
            }
        }

        pDialogSystem.onDialogEnd += StartNextDay;
        pDialogSystem.StartNewDialogues();
    }

    private void StartNextDay()
    {
        currentTiming = 0;

        //display morning text for different days
        switch(Day)
        {
            case 0:
                {
                    if (GameManager.isMale == true)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/MaleMorning1.txt";
                    }
                    else if(GameManager.isMale == false)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/FemaleMorning1.txt";
                    }

                    break;
                }
            case 1:
                {
                    if (GameManager.isMale == true)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/MaleMorning2.txt";
                    }
                    else if (GameManager.isMale == false)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/FemaleMorning2.txt";
                    }

                    break;
                }
            case 2:
                {
                    if (GameManager.isMale == true)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/MaleMorning3.txt";
                    }
                    else if (GameManager.isMale == false)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/FemaleMorning3.txt";
                    }

                    break;
                }
            case 3:
                {
                    if (GameManager.isMale == true)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/MaleMorning4.txt";
                    }
                    else if (GameManager.isMale == false)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/FemaleMorning4.txt";
                    }

                    break;
                }
            case 4:
                {
                    if (GameManager.isMale == true)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/MaleMorning5.txt";
                    }
                    else if (GameManager.isMale == false)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/FemaleMorning5.txt";
                    }

                    break;
                }
        }

        pDialogSystem.StartNewDialogues();

        warningGiven = false;
        IsNight = false;
        NextDay = false;
    }
}
