using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundTransparencyAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public bool CoroutineRunning = false;
    [SerializeField] CanvasGroup canvasgroup;
    [SerializeField] public float TransparencyMax = 0.5f;
    [SerializeField] float accuracy = 0.01f;
    [SerializeField] float LerpSpeed = 0.01f;
    public Coroutine currentcoroutine;

    void Start()
    {
        //canvasgroup = GetComponent<CanvasGroup>();
    }

    public IEnumerator Anim(float TargetTrans, float Accuracy)
    {
        float time = 0;
        CoroutineRunning = true;
        while (true)
        {
            canvasgroup.alpha = Mathf.Lerp(canvasgroup.alpha, TargetTrans, time);
            time += Time.deltaTime * LerpSpeed;
            if (Mathf.Abs(canvasgroup.alpha - TargetTrans) <= Accuracy)
            {
                Debug.Log("Background Anim End");
                canvasgroup.alpha = TargetTrans;
                CoroutineRunning = false;
                yield break;
            }
            yield return null;
        }
    }
    void Update()
    {
        //canvasgroup.alpha = Mathf.Lerp(canvasgroup.alpha, 0.5f, Time.deltaTime);
    }

    private void OnEnable()
    {
        //Debug.Log("ENABLED");
        //if (currentcoroutine != null)
        //{
        //    StopCoroutine(currentcoroutine);
        //    CoroutineRunning = false;
        //}
        //currentcoroutine = StartCoroutine(Anim(TransparencyMax, accuracy));
    }

    private void OnDisable()
    {
        if (currentcoroutine != null)
        {
            StopCoroutine(currentcoroutine);
            CoroutineRunning = false;
        }
        canvasgroup.alpha = 0;
    }
}
