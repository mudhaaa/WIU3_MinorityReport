using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class ClockUIManager : MonoBehaviour
{
    const float StartingFill = 0.31f;
    public UnityEngine.UI.Image Clock;
    public TimeSystem Timing;
    
    // Update is called once per frame
    void Update()
    {
        Clock.fillAmount = StartingFill + ((Timing.currentTiming / TimeSystem.LengthOfTime) * 0.69f);
    }
}
