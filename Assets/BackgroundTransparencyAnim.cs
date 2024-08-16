using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundTransparencyAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public bool CoroutineRunning = false;
    [SerializeField] public CanvasGroup canvasgroup;
    [SerializeField] public float TransparencyMax = 0.5f;
    [SerializeField] float LerpSpeed = 0.01f;
    public Coroutine currentcoroutine;

    void Start()
    {
        //canvasgroup = GetComponent<CanvasGroup>();
    }

    public IEnumerator Anim(float TargetTrans, float Accuracy)
    {
        CoroutineRunning = true;
        float time = 0;
        while (CoroutineRunning)
        {
            canvasgroup.alpha = Mathf.Lerp(canvasgroup.alpha, TargetTrans, time);
            time += Time.deltaTime * LerpSpeed;
            if (Mathf.Abs(canvasgroup.alpha - TargetTrans) <= Accuracy)
            {
                canvasgroup.alpha = TargetTrans;
                CoroutineRunning = false;
                yield break;
            }
            yield return null;
        }
        yield break;
    }

    public IEnumerator AppearAnim(float TargetTrans, float Accuracy, float DelayTime = 0)
    {
        CoroutineRunning = true;
        float time = 0;
        bool Delay = true;
        while (true)
        {
            canvasgroup.alpha = Mathf.Lerp(canvasgroup.alpha, TargetTrans, time);
            time += Time.deltaTime * LerpSpeed;
            if (Mathf.Abs(canvasgroup.alpha - TargetTrans) <= Accuracy)
            {
                canvasgroup.alpha = TargetTrans;
                break;
            }
            else
            {
                yield return null;
            }
        }
        if (Delay)
        {
            yield return new WaitForSeconds(DelayTime);
        }
        time = 0;
        while (true)
        {
            canvasgroup.alpha = Mathf.Lerp(canvasgroup.alpha, 0.0f, time);
            time += Time.deltaTime * LerpSpeed;
            if (Mathf.Abs(canvasgroup.alpha - 0.0f) <= Accuracy)
            {
                canvasgroup.alpha = 0.0f;
                break;
            }
            else
            {
                yield return null;
            }
        }
        CoroutineRunning = false;
        yield break;
    }
    void Update()
    {
        //canvasgroup.alpha = Mathf.Lerp(canvasgroup.alpha, 0.5f, Time.deltaTime);
    }

    private void OnEnable()
    {
        //Debug.Log("ENABLED");
        //if (CoroutineRunning)
        //{
        //    StopCoroutine(currentcoroutine);
        //    CoroutineRunning = false;
        //}
        //currentcoroutine = StartCoroutine(Anim(TransparencyMax, accuracy));
    }

    private void OnDisable()
    {
        if (CoroutineRunning)
        {
            StopCoroutine(currentcoroutine);
            CoroutineRunning = false;
        }
        canvasgroup.alpha = 0;
    }
}
