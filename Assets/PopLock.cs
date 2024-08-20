using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PopLock : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float StartLockRotationSpeed = 50.0f;
    [SerializeField] float LockRotationSpeed = 1.0f;
    [SerializeField] float SpeedMultiplier = 1.0f;
    [SerializeField] GameObject Stick;
    [SerializeField] int MaxHits = 2;
    [SerializeField] StickFindTargetCircle stickscript;
    [SerializeField] BackgroundTransparencyAnim BlackBackground;
    [SerializeField] GameObject MainGame;
    [SerializeField] GameObject MiniGame;
    public GameObject InvetigationGUI;
    public TextMeshProUGUI investigationtext;
    void OnEnable()
    {
        SpeedMultiplier = 1.0f;
        InvetigationGUI.SetActive(true);
        LockRotationSpeed = StartLockRotationSpeed;
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        investigationtext.text = "Turns: " + (stickscript.Hits) + " / " + (MaxHits);
        if (stickscript.Hits >= MaxHits)
        {
            if (BlackBackground.CoroutineRunning == false)
            {
                BlackBackground.StartCoroutine(BlackBackground.AppearAnim(1.0f, 0.01f, 0.25f));
            }
            if (BlackBackground.canvasgroup.alpha >= 1.0f)
            {
                MiniGame.SetActive(false);
                MainGame.SetActive(true);
            }
        }
        if (stickscript.Hit)
        {
            SpeedMultiplier *= -1.1f;
        }
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + (Time.deltaTime * LockRotationSpeed * SpeedMultiplier));
    }
    void OnDisable()
    {
        InvetigationGUI.SetActive(false);
    }
}
