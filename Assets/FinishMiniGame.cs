using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TimeSystem;

public class FinishMiniGame : MonoBehaviour
{
    public TimeSystem pTimeSystem;
    public IOMiniGame MiniGameInteractable;
    public bool finishgame = false;
    public bool Chore = false;
    public bool RestartPerDayAvailable = false;

    public bool FinishedGame
    {
        get
        {
            return finishgame;
        }
        set
        {
            if (value != finishgame)
            {
                if (value)
                {
                    pTimeSystem.ChoresDoneForTheDay++;
                    MiniGameInteractable.Interactable = false;
                }
                finishgame = value;
            }
        }
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        pTimeSystem.pOnDayStart += OnDayStart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDayStart()
    {
        if (RestartPerDayAvailable)
        {
            FinishedGame = false;
            MiniGameInteractable.Interactable = true;
        }
    }
}
