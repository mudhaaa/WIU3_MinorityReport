using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ArcadeExit : MonoBehaviour
{
    [SerializeField] GameObject MainGame;
    [SerializeField] GameObject MiniGameUI;
    [SerializeField] BackgroundTransparencyAnim BlackBackground;
    public Volume CameraEffects;
    public VolumeProfile NormalProf;

    public TimeSystem pTimeSystem;

    public FinishMiniGame FinishMiniGame;
    [SerializeField] bool Arcade;
    [SerializeField] Sanity PlayerSanity;

    bool Exit = false;
    // Start is called before the first frame update
    void OnEnable()
    {
        Exit = false;
        pTimeSystem.pOnDayEnd += OnDayEnd;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Exit = true;
            Debug.Log("Arcade Exit");
        }
        if (Exit)
        {
            if (BlackBackground.CoroutineRunning == false)
            {
                BlackBackground.StartCoroutine(BlackBackground.AppearAnim(1.0f, 0.01f, 0.25f));
            }
            if (BlackBackground.canvasgroup.alpha >= 1.0f)
            {
                CameraEffects.profile = NormalProf;
                gameObject.SetActive(false);
                MainGame.SetActive(true);
                if (FinishMiniGame != null)
                {
                    FinishMiniGame.FinishedGame = true;
                }
                if (MiniGameUI != null)
                {
                    MiniGameUI.SetActive(false);
                }
                if (Arcade)
                {
                    PlayerSanity.ISanity += 5;
                }
            }
        }
    }

    private void OnDisable()
    {
        pTimeSystem.pOnDayEnd -= OnDayEnd;
    }

    public void OnDayEnd()
    {
        Exit = true;
        Debug.Log("Arcade Exit");
    }
}
