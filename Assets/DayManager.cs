using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    [SerializeField] float DayMaxMin = 8;
    [SerializeField] float TimeOfCurrentDay = 0;
    int DayCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeOfCurrentDay += Time.deltaTime;

        if (TimeOfCurrentDay > DayMaxMin * 60)
        {
            TimeOfCurrentDay = 0;
            DayCount++;
        }
    }
}
