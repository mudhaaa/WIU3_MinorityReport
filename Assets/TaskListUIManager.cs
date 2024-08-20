using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TaskListUIManager : MonoBehaviour
{
    public Animator animator;

    public Text Day;
    public Text Task1;
    public Text Task2;
    public Text Task3;

    public TimeSystem timeSystem;
    public EventSystem eventSystem;

    public string[] Task1s;
    public string[] Task2s;
    public string[] Task3s;

    public KitchenGame kitchenGame;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        timeSystem.pOnDayStart += kitchenGame.OnDayStart;
        timeSystem.pOnDayStart += OnDayStart;
    }

    private void Update()
    {
        if (eventSystem.currentSelectedGameObject == gameObject)
        {
            eventSystem.SetSelectedGameObject(null);
        }

        if (animator.GetBool("Highlighted") == true)
        {
            animator.Play("Show");
        }
        else if (animator.GetBool("Normal") == true)
        {
            animator.Play("Hide");
        }
    }

    public void OnDayStart()
    {
        Day.text = "Day " + (timeSystem.Day + 1);

        Task1.text = "1. " + Task1s[timeSystem.Day];

        if(Task2s[timeSystem.Day] != "")
        {
            Task2.text = "2. " + Task2s[timeSystem.Day] + '(' + KitchenGame.FoodNames[(int)kitchenGame.FoodToMake] + ')';
        }
        else
        {
            Task2.text = "";
        }

        if (Task3s[timeSystem.Day] != "")
        {
            Task3.text = "3. " + Task3s[timeSystem.Day];
        }
        else
        {
            Task3.text = "";
        }
    }
}
