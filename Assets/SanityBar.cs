using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
    Slider slider;
    [SerializeField] Sanity SanityScript;
    BackgroundTransparencyAnim transparencyanim;
    [SerializeField] GameObject InventoryGUI;


    public bool CoroutineRunning = false;
    [SerializeField] float LerpSpeed = 0.01f;
    public Coroutine currentcoroutine;

    // Start is called before the first frame update
    void Start()
    {
        transparencyanim = GetComponent<BackgroundTransparencyAnim>();
        slider = GetComponent<Slider>();
        SanityScript.SanityChanged += ChangeValue;
        slider.maxValue = SanityScript.maxsanity;
        slider.value = SanityScript.ISanity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeValue(float newvalue, float maxnewvalue)
    {
        //slider.value = newvalue;
        slider.maxValue = maxnewvalue;


        if (CoroutineRunning)
        {
            CoroutineRunning = false;
            StopCoroutine(currentcoroutine);
        }
        currentcoroutine = StartCoroutine(Anim(newvalue, 0.01f));
    }

    public IEnumerator Anim(float TargetValue, float Accuracy)
    {
        CoroutineRunning = true;
        if (!InventoryGUI.activeSelf)
        {
            if (transparencyanim.CoroutineRunning)
            {
                transparencyanim.CoroutineRunning = false;
                StopCoroutine(transparencyanim.currentcoroutine);
            }
            transparencyanim.currentcoroutine = StartCoroutine(transparencyanim.Anim(1.0f, 0.01f));
        }
        float time = 0;
        while (CoroutineRunning)
        {
            slider.value = Mathf.Lerp(slider.value, TargetValue, time);
            time += Time.deltaTime * LerpSpeed;
            if (Mathf.Abs(slider.value - TargetValue) <= Accuracy)
            {
                slider.value = TargetValue;
                break;
            }
            yield return null;
        }
        if (!InventoryGUI.activeSelf)
        {
            if (transparencyanim.CoroutineRunning)
            {
                transparencyanim.CoroutineRunning = false;
                StopCoroutine(transparencyanim.currentcoroutine);
            }
            transparencyanim.currentcoroutine = StartCoroutine(transparencyanim.Anim(0.0f, 0.01f));
        }
        CoroutineRunning = false;
        yield break;
    }
}
