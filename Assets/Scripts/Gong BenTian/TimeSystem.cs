using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TimeSystem : MonoBehaviour
{
    public delegate void OnDayStart();
    public OnDayStart pOnDayStart;

    public delegate void OnDayEnd();
    public OnDayEnd pOnDayEnd;

    public DialogSystem pDialogSystem;
    public InventoryManager pInventoryManager;

    public SceneFunctions sceneFunctions;

    public Animator globalLightAnimator;

    public GameObject Abuser;

    public const int TotalOfDay = 5;
    public int Day;

    public const float LengthOfTime = 480;
    public static float NormalTimeMultipler = 1.0f;
    public const float DialogTimeMultipler = 0.0f;
    public static float TimeMultipler = 1.0f;

    public float currentTiming;

    public bool warningGiven;

    public bool IsNight;
    public bool NextDay;
    public Sanity PlayerSanity;
    public float SanityReductionMultiplier = 1.0f;

    public int ChoresDoneForTheDay = 0;
    public int ChoresToBeDoneToday = 1;

    bool StartOfGame = true;
    private void Start()
    {
        StartNextDay();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTiming == 0 && pDialogSystem.gameObject.activeSelf == false && Day <= 4)
        {
            if (StartOfGame == false)
            {
                if (ChoresDoneForTheDay < ChoresToBeDoneToday)
                {
                    SanityReductionMultiplier = 2.0f;
                }
                else
                {
                    SanityReductionMultiplier = 1.0f;
                }

                PlayerSanity.ISanity -= 15 * SanityReductionMultiplier;
                ChoresDoneForTheDay = 0;
            }
            else
            {
                StartOfGame = false;
            }
        }
        
        Debug.Log(TimeMultipler);
        if (Day < 4)
        {
            currentTiming += Time.deltaTime * TimeMultipler;
        }
        else
        {
            currentTiming = 1.0F;
        }
        
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
        else if(IsNight == true && NextDay == true && Day < TotalOfDay)
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
        if (pOnDayEnd != null)
        {
            pOnDayEnd();
            pOnDayEnd = null;
        }

        IsNight = true;

        ++Day;
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

        pDialogSystem.onDialogEnd += StartNextDay;
        pDialogSystem.StartNewDialogues();
    }

    private void StartNextDay()
    {
        pDialogSystem.onDialogEnd -= StartNextDay;

        currentTiming = 0;
        NormalTimeMultipler = 1.0f;
        //display morning text for different days
        switch (Day)
        {
            case 0:
                {
                    if (GameManager.isMale == true)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/MaleDay1Start.txt";
                    }
                    else if(GameManager.isMale == false)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/FemaleDay1Start.txt";
                    }

                    break;
                }
            case 1:
                {
                    if (GameManager.isMale == true)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/MaleDay2Start.txt";
                    }
                    else if (GameManager.isMale == false)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/FemaleDay2Start.txt";
                    }

                    break;
                }
            case 2:
                {
                    if (GameManager.isMale == true)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/MaleDay3Start.txt";
                    }
                    else if (GameManager.isMale == false)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/FemaleDay3Start.txt";
                    }

                    break;
                }
            case 3:
                {
                    if (GameManager.isMale == true)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/MaleDay4Start.txt";
                    }
                    else if (GameManager.isMale == false)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/FemaleDay4Start.txt";
                    }

                    break;
                }
            case 4:
                {
                    if (GameManager.isMale == true)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/MaleDay5Start.txt";
                    }
                    else if (GameManager.isMale == false)
                    {
                        pDialogSystem.FilePath = "Assets/Dialog/FemaleDay5Start.txt";
                    }

                    Abuser.SetActive(true);
                    break;
                }
        }

        pDialogSystem.StartNewDialogues();

        warningGiven = false;
        IsNight = false;
        NextDay = false;

        if(pOnDayStart != null)
        {
            pOnDayStart();
        }
    }
}
