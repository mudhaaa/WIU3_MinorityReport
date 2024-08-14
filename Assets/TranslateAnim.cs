using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TranslateAnim : MonoBehaviour
{
    public bool CoroutineRunning = false;
    [SerializeField] public Vector2 TargetPosition;
    [SerializeField] float LerpSpeed = 0.01f;
    public Coroutine currentcoroutine;

    void Awake()
    {
        TargetPosition = transform.localPosition;
        Debug.Log(TargetPosition);
        transform.localPosition = new Vector2(TargetPosition.x , -Screen.height);
        //canvasgroup = GetComponent<CanvasGroup>();
    }

    public IEnumerator Anim(Vector2 Targetpos, float Accuracy)
    {
        float time = 0;
        CoroutineRunning = true;
        while (CoroutineRunning)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, Targetpos, time);
            time += Time.deltaTime * LerpSpeed;
            if (Vector2.Distance(transform.localPosition, Targetpos) < Accuracy)
            {
                transform.localPosition = Targetpos;
                CoroutineRunning = false;
                yield break;
            }
            yield return null;
        }
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
        //currentcoroutine = StartCoroutine(Anim(TargetPosition, accuracy));
    }

    private void OnDisable()
    {
        if (CoroutineRunning)
        {
            StopCoroutine(currentcoroutine);
            CoroutineRunning = false;
        }
        transform.localPosition = new Vector2(TargetPosition.x, -Screen.height);
        //canvasgroup.alpha = 0;
    }
}
