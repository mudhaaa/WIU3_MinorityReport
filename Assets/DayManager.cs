using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    //[SerializeField] float DayMaxMinutes = 8;
    //[SerializeField] float TimeOfCurrentDay = 0;
    //[SerializeField] private DialogSystem dialogSystem;

    //public int currDay = 0;

    //string[] dialogueMPaths =  { "Assets/Dialog/MaleDay1Start.txt", "Assets/Dialog/MaleDay2Start.txt", "Assets/Dialog/MaleDay3Start.txt", "Assets/Dialog/MaleDay4Start.txt", "Assets/Dialog/MaleDay5Start.txt" };
    //string[] dialogueFPaths = { "Assets/Dialog/FemaleDay1Start.txt", "Assets/Dialog/FemaleDay2Start.txt", "Assets/Dialog/FemaleDay3Start.txt", "Assets/Dialog/FemaleDay4Start.txt", "Assets/Dialog/FemaleDay5Start.txt" };


    //bool timeStopped;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    SetTodayDialogue();
    //    StartCoroutine(PlayStartDialogue());
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (!timeStopped && TimeOfCurrentDay > DayMaxMinutes * 60)
    //    {
    //        currDay++;
    //        StartCoroutine(PlayStartDialogue());
    //    }
    //    if (!timeStopped && TimeOfCurrentDay <= DayMaxMinutes * 60)
    //    {
    //        TimeOfCurrentDay += Time.deltaTime;
    //    }
    //}

    //void SetTodayDialogue()
    //{
    //    dialogSystem.FilePath = dialogueMPaths[currDay];
    //}

    //IEnumerator PlayStartDialogue()
    //{
    //    //SetTodayDialogue();
    //    //dialogSystem.StartNewDialogues();
    //    //timeStopped = true;

    //    //yield return new WaitUntil(() => dialogSystem.IsDialogueEnded);

    //    //timeStopped = false;
    //    //TimeOfCurrentDay = 0;

    //}
}
